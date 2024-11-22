using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.DetallePlatos
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public EditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetallePlato DetallePlato { get; set; } = default!;

        public SelectList Platos { get; set; } = default!;
        public SelectList Ingredientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetallesPlato == null)
            {
                return NotFound();
            }

            // Cargar el DetallePlato a editar
            DetallePlato = await _context.DetallesPlato.FirstOrDefaultAsync(dp => dp.IdDetalle == id);

            if (DetallePlato == null)
            {
                return NotFound();
            }

            // Cargar listas de selección
            await LoadSelectListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || DetallePlato == null)
            {
                await LoadSelectListsAsync();
                //return Page();
            }

            // Cargar el registro existente desde la base de datos
            var detalleExistente = await _context.DetallesPlato.FirstOrDefaultAsync(dp => dp.IdDetalle == DetallePlato.IdDetalle);

            if (detalleExistente == null)
            {
                return NotFound();
            }

            // Validar que los IDs de las entidades relacionadas existen
            var platoExists = await _context.Platos.AnyAsync(p => p.IdPlato == DetallePlato.IdPlato);
            var ingredienteExists = await _context.Ingredientes.AnyAsync(i => i.IdIngrediente == DetallePlato.IngredienteId);

            if (!platoExists || !ingredienteExists)
            {
                ModelState.AddModelError("", "Plato o Ingrediente no válido.");
                await LoadSelectListsAsync();
                return Page();
            }

            // Actualizar las propiedades del registro existente
            detalleExistente.IdPlato = DetallePlato.IdPlato;
            detalleExistente.IngredienteId = DetallePlato.IngredienteId;
            detalleExistente.Cantidad = DetallePlato.Cantidad;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePlatoExists(DetallePlato.IdDetalle))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadSelectListsAsync()
        {
            // Cargar nombres de Platos e Ingredientes
            Platos = new SelectList(await _context.Platos.Select(p => new { p.IdPlato, p.Nombre }).ToListAsync(), "IdPlato", "Nombre");
            Ingredientes = new SelectList(await _context.Ingredientes.Select(i => new { i.IdIngrediente, i.Nombre }).ToListAsync(), "IdIngrediente", "Nombre");
        }

        private bool DetallePlatoExists(int id)
        {
            return _context.DetallesPlato.Any(dp => dp.IdDetalle == id);
        }
    }
}

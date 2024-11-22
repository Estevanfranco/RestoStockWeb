using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.DetallePlatos
{
    public class DetCreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DetCreateModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetallePlato detallePlato { get; set; } = default!;

        public SelectList Platos { get; set; } = default!;
        public SelectList Ingredientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadSelectListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.DetallesPlato == null || detallePlato == null)
            {
                await LoadSelectListsAsync();
                //return Page();
            }

            // Validar que los IDs existen
            var platoExists = await _context.Platos.AnyAsync(p => p.IdPlato == detallePlato.IdPlato);
            var ingredienteExists = await _context.Ingredientes.AnyAsync(i => i.IdIngrediente == detallePlato.IngredienteId);

            if (!platoExists || !ingredienteExists)
            {
                ModelState.AddModelError("", "Plato o Ingrediente no válido.");
                await LoadSelectListsAsync();
                return Page();
            }

            _context.DetallesPlato.Add(detallePlato);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private async Task LoadSelectListsAsync()
        {
            // Cargar nombres de Platos e Ingredientes
            Platos = new SelectList(await _context.Platos.Select(p => new { p.IdPlato, p.Nombre }).ToListAsync(), "IdPlato", "Nombre");
            Ingredientes = new SelectList(await _context.Ingredientes.Select(i => new { i.IdIngrediente, i.Nombre }).ToListAsync(), "IdIngrediente", "Nombre");
        }
    }
}



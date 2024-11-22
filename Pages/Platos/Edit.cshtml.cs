using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Platos
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public EditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plato Plato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            // Cargar el plato a editar
            Plato = await _context.Platos.FirstOrDefaultAsync(p => p.IdPlato == id);

            if (Plato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            // Validar si el plato existe
            var platoExists = await _context.Platos.AnyAsync(p => p.IdPlato == Plato.IdPlato);

            if (!platoExists)
            {
                return NotFound();
            }

            // Actualizar el plato en el contexto
            try
            {
                _context.Attach(Plato).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(Plato.IdPlato))
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

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(p => p.IdPlato == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.DetallePlatos
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetallePlato DetallePlato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetallesPlato == null)
            {
                return NotFound();
            }

            // Cargar el detalle del plato y sus relaciones (Plato e Ingrediente)
            DetallePlato = await _context.DetallesPlato
                .Include(dp => dp.Plato)
                .Include(dp => dp.Ingrediente)
                .FirstOrDefaultAsync(m => m.IdDetalle == id);

            if (DetallePlato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DetallesPlato == null)
            {
                return NotFound();
            }

            // Buscar el registro a eliminar
            var detallePlato = await _context.DetallesPlato.FindAsync(id);

            if (detallePlato != null)
            {
                DetallePlato = detallePlato;
                _context.DetallesPlato.Remove(DetallePlato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

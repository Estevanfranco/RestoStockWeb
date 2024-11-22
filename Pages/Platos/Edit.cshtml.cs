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
        public Plato plato { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Platos == null)
			{
				return NotFound();
			}

			var platos = await _context.Platos.FirstOrDefaultAsync(m => m.IdPlato == id);

			if (platos == null)
			{
				return NotFound();
			}

			plato = platos; // Carga el plato correspondiente
			return Page();
		}



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.Attach(plato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(plato.IdPlato))
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
            return (_context.Platos?.Any(e => e.IdPlato == id)).GetValueOrDefault();
        }
    }
}
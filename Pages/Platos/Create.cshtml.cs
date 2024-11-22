using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Platos
{
    public class PlaCreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public PlaCreateModel(RestoStockContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plato plato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Platos == null || plato == null)
            {
                //return Page();
            }

            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

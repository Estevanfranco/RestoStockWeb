using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Ingredientes
{
    public class IngCreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IngCreateModel(RestoStockContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ingrediente ingrediente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Ingredientes == null || ingrediente == null)
            {
                //return Page();
            }

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}






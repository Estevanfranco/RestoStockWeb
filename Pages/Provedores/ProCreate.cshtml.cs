using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Proveedores
{
    public class ProCreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public ProCreateModel(RestoStockContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Proveedor proveedor { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Proveedores == null || proveedor == null)
            {
                //return Page();
            }

            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ProIndex");
        }
    }
}

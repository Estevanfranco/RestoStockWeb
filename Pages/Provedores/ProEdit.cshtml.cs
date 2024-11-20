using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Provedores
{
    public class ProEditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public ProEditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor proveedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proveedores == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores.FirstOrDefaultAsync(m => m.IdProveedor == id);

            if (proveedores == null)
            {
                return NotFound();
            }

            proveedor = proveedores;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.Attach(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(proveedor.IdProveedor))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ProIndex");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Proveedores?.Any(e => e.IdProveedor == id)).GetValueOrDefault();
        }
    }
}

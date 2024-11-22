using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Provedores
{
    public class ProDeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public ProDeleteModel(RestoStockContext context)
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

            var Proveedor = await _context.Proveedores.FirstOrDefaultAsync(m => m.IdProveedor == id);

            if (Proveedor == null)
            {
                return NotFound();
            }
            else
            {
                proveedor = Proveedor;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categor�as en el contexto
            if (id == null || _context.Proveedores == null)
            {
                return NotFound();
            }

            // Busca la categor�a con el ID especificado
            var Proveedor = await _context.Proveedores.FindAsync(id);

            // Si la categor�a no se encuentra, devuelve un error 404
            if (Proveedor != null)
            {

                proveedor = Proveedor;
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
            // Redirige a la p�gina de �ndice despu�s de eliminar la categor�a
            return RedirectToPage("./ProIndex");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Proveedores
{
    public class ProIndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public ProIndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Proveedor> proveedor { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.Proveedores != null)
            {
                proveedor = await _context.Proveedores.ToListAsync();
            }
        }
    }
}

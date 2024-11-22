using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Pedidos
{
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Pedido> pedidos { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.Pedidos != null)
            {
                pedidos = await _context.Pedidos.ToListAsync();
            }
        }
    }
}

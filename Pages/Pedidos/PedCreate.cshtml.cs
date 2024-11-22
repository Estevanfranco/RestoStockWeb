using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Pedidos
{
    public class PedCreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public PedCreateModel(RestoStockContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pedido pedido { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pedidos == null || pedido == null)
            {
                //return Page();
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./PedIndex");
        }
    }
}

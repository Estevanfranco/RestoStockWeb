using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Pedidos
{
    public class PedEditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public PedEditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pedido pedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos.FirstOrDefaultAsync(m => m.IdPedido == id);

            if (pedidos == null)
            {
                return NotFound();
            }

            pedido = pedidos;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.Attach(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(pedido.IdPedido))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./PedIndex");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.IdPedido == id)).GetValueOrDefault();
        }
    }
}

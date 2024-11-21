using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Pedidos
{
    public class PeDeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public PeDeleteModel(RestoStockContext context)
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

            var Pedido = await _context.Pedidos.FirstOrDefaultAsync(m => m.IdPedido == id);

            if (Pedido == null)
            {
                return NotFound();
            }
            else
            {
                pedido = Pedido;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categor�as en el contexto
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            // Busca la categor�a con el ID especificado
            var Pedido = await _context.Pedidos.FindAsync(id);

            // Si la categor�a no se encuentra, devuelve un error 404
            if (Pedido != null)
            {

                pedido = Pedido;
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
            // Redirige a la p�gina de �ndice despu�s de eliminar la categor�a
            return RedirectToPage("./PedIndex");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Userss
{
    public class UserDeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public UserDeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var Users = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (Users == null)
            {
                return NotFound();
            }
            else
            {
                User = Users;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categorías en el contexto
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            // Busca la categoría con el ID especificado
            var Users = await _context.Users.FindAsync(id);

            // Si la categoría no se encuentra, devuelve un error 404
            if (Users != null)
            {

                User = Users;
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }
            // Redirige a la página de índice después de eliminar la categoría
            return RedirectToPage("./UserIndex");
        }
    }
}

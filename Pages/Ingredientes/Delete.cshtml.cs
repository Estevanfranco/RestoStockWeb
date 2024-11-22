using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace RestoStockWeb.Pages.Ingredientes
{
    public class DeleteModel : PageModel
    {
		private readonly RestoStockContext _context;

		public DeleteModel(RestoStockContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Ingrediente ingrediente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Ingredientes == null)
			{
				return NotFound();
			}

			var Ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(m => m.IdIngrediente == id);

			if (Ingrediente == null)
			{
				return NotFound();
			}
			else
			{
				ingrediente = Ingrediente;
			}

			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			// Verifica si el ID es nulo o si no hay categorías en el contexto
			if (id == null || _context.Ingredientes == null)
			{
				return NotFound();
			}

			// Busca la categoría con el ID especificado
			var Ingrediente = await _context.Ingredientes.FindAsync(id);

			// Si la categoría no se encuentra, devuelve un error 404
			if (Ingrediente != null)
			{

				ingrediente = Ingrediente;
				_context.Ingredientes.Remove(ingrediente);
				await _context.SaveChangesAsync();
			}
			// Redirige a la página de índice después de eliminar la categoría
			return RedirectToPage("./Index");
		}
	}
}

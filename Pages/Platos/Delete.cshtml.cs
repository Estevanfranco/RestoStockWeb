using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace RestoStockWeb.Pages.Platos
{
	public class DeleteModel : PageModel
	{
		private readonly RestoStockContext _context;

		public DeleteModel(RestoStockContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Plato plato { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Platos == null)
			{
				return NotFound();
			}

			var Plato = await _context.Platos.FirstOrDefaultAsync(m => m.IdPlato == id);

			if (Plato == null)
			{
				return NotFound();
			}
			else
			{
				plato = Plato;
			}

			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			// Verifica si el ID es nulo o si no hay categor�as en el contexto
			if (id == null || _context.Platos == null)
			{
				return NotFound();
			}

			// Busca la categor�a con el ID especificado
			var Plato = await _context.Platos.FindAsync(id);

			// Si la categor�a no se encuentra, devuelve un error 404
			if (Plato != null)
			{

				plato = Plato;
				_context.Platos.Remove(plato);
				await _context.SaveChangesAsync();
			}
			// Redirige a la p�gina de �ndice despu�s de eliminar la categor�a
			return RedirectToPage("./Index");
		}
	}
}
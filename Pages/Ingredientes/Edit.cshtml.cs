using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Ingredientes
{
	public class EditModel : PageModel
	{
		private readonly RestoStockContext _context;

		public EditModel(RestoStockContext context)
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

			var ingredientes = await _context.Ingredientes.FirstOrDefaultAsync(m => m.IdIngrediente == id);

			if (ingredientes == null)
			{
				return NotFound();
			}

			ingrediente = ingredientes;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				//return Page();
			}

			_context.Attach(ingrediente).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!IngredienteExists(ingrediente.IdIngrediente))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool IngredienteExists(int id)
		{
			return (_context.Ingredientes?.Any(e => e.IdIngrediente == id)).GetValueOrDefault();
		}
	}
}


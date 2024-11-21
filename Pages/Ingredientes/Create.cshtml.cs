using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using RestoStockWeb.Models;
using RestoStockWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace RestoStockWeb.Pages.Ingredientes
{
    public class IngCreateModel : PageModel
    {
		private readonly RestoStockContext _context;

		public IngCreateModel(RestoStockContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]

		public Ingrediente Ingrediente { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Ingredientes == null || Ingrediente == null)
			{
				return Page();
			}
			_context.Ingredientes.Add(Ingrediente);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}

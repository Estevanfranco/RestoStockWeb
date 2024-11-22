using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Models;
using RestoStockWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace RestoStockWeb.Pages.Ingredientes
{
	public class IndexModel : PageModel
	{
		private readonly RestoStockContext _context;

		public IndexModel(RestoStockContext context)
		{
			_context = context;
		}

		public IList<Ingrediente> Ingrediente { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.Ingredientes != null)
			{
				Ingrediente = await _context.Ingredientes.ToListAsync();
			}
		}
	}
}

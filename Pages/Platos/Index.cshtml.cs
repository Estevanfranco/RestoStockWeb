using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using RestoStockWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace RestoStockWeb.Pages.Platos
{
    public class IndexModel : PageModel
	{
		private readonly RestoStockContext _context;

		public IndexModel(RestoStockContext context)
		{
			_context = context;
		}

		public IList<Plato> Plato { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.Ingredientes != null)
			{
				Plato = await _context.Platos.ToListAsync();
			}
		}
	}
}

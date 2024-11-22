using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockWeb.Data;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.DetallePlatos
{
	public class IndexModel : PageModel
	{
		private readonly RestoStockContext _context;

		public IndexModel(RestoStockContext context)
		{
			_context = context;
		}
        [BindProperty]
        public IList<DetallePlato> DetallePlato { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.DetallesPlato != null)
			{
				DetallePlato = await _context.DetallesPlato.ToListAsync();
			}
		}
	}
}

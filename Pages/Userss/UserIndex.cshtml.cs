using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

namespace RestoStockWeb.Pages.Userss
{
    public class UserIndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public UserIndexModel(RestoStockContext context)
        {
            _context = context;
        }
     
        public IList<User> Users { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.Users != null)
            {
                Users = await _context.Users.ToListAsync();
            }
        }
    }
}


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Data;
using RestoStockWeb.Models;

using System.Security.Claims;

namespace Autenticacion.Pages.Account
{
	public class LoginModel : PageModel
	{
        /*[BindProperty]
		public Users User { get; set; }
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
           

            if (User.Email == "correo@gmail" && User.Password == "123")
			{
				// Se crea los Claim, datos a almacenar en la Cookie
				var claims = new List<Claim>
				{
				new Claim(ClaimTypes.Name, "admin"),
				new Claim(ClaimTypes.Email, User.Email)
				};

				// Se asocia los claims creados a un nombre de una Cookie
				var identity = new ClaimsIdentity(claims, "MyCookieAuth");

				// Se agrega la identidad creada al ClaimsPrincipal de la aplicación
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

				// Se registra exitosamente la autenticación y se crea la cookie en el navegador
				await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
				return RedirectToPage("/Index");
			}

			return Page();
		}*/

        private readonly RestoStockContext _context;

        public LoginModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Users { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar el usuario en la base de datos
            var userInDb = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Users.Email && u.Password == Users.Password);

            if (userInDb != null)
            {
                // Crear los Claims basados en los datos del usuario en la base de datos
                var claims = new List<Claim>
            {
                  // Puedes ajustar este valor según la información que quieras almacenar
                new Claim(ClaimTypes.Email, userInDb.Email)
            };

                // Asociar los claims a una Cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                // Agregar la identidad creada al ClaimsPrincipal
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                // Registrar la autenticación y crear la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");  // Redirigir a la página principal
            }

            // Si las credenciales no son válidas, se muestra la página actual con un error
            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
            return Page();
        }
    }
}

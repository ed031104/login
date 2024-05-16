using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller

    {

        private readonly UserService _userService;
        public LoginController(UserService service)
        {
            _userService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

    
		[HttpPost]
		public async Task<IActionResult> Login(User user)
		{
                
                bool response = _userService.Login(user.Email, user.Contrasena);
                User userSearch = _userService.SearchUserForEmail(user.Email);
                
                if (response == true)
                {
                var claims = new[]
                {
                        new Claim(ClaimTypes.NameIdentifier, userSearch.Id.ToString()),
                        new Claim(ClaimTypes.Name, userSearch.Nombre),
                        new Claim(ClaimTypes.Email, userSearch.Apellido),
                    };
                    
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    TempData["SuccessMessage"] = "Login successful!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "User not found or incorrect password.";
                    return RedirectToAction("Index", "Login");
                }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}

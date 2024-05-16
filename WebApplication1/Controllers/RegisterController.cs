using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Services;
using BD;


namespace WebApplication1.Controllers
{
	
	public class RegisterController : Controller
	{
		private readonly UserService _userService;

		public RegisterController(UserService service)
		{
			_userService = service;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult RegisterUser(User user)
		{
			if (ModelState.IsValid)
			{
			     _userService.AddUser(user);	
				return RedirectToAction("Index", "Login");
			}
			return View(user);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

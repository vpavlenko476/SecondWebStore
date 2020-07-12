using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Entities.Identity;

namespace WebStore.Controllers
{
	public class AccauntController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManaher;
		public AccauntController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManaher = signInManager;
		}
		public IActionResult Register => View();
		public IActionResult Login => View();
		public IActionResult Logout => RedirectToAction("Index", "Home");
		public IActionResult AccessDenied() => new StatusCodeResult(404);
	}
}
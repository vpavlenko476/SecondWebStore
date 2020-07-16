using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Entities.Identity;
using System.Threading.Tasks;
using WebStore.ViewModels.Identity;

namespace WebStore.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		#region Registration
		public IActionResult Registration() => View();

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration(RegisterUserViewModel userModel)
		{
			if (!ModelState.IsValid)
			{
				return View(userModel);
			}

			var user = new User() 
			{
				UserName = userModel.UserName,				
			};
			var registrationResult = await _userManager.CreateAsync(user, userModel.Password);

			if(registrationResult.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, Role.User);
				await _signInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Home");
			}
			
			foreach(var error in registrationResult.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
			return View(userModel);
		}
		#endregion

		#region Login
		public IActionResult Login(string returnUrl) => View(new LoginViewModel() { ReturnUrl = returnUrl});

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel userModel)
		{
			if (!ModelState.IsValid)
			{
				return View(userModel);
			}

			var loginResult = await _signInManager.PasswordSignInAsync(
				userModel.UserName,
				userModel.Password,
				userModel.RememberMe,
				false);

			if(loginResult.Succeeded)
			{
				if(Url.IsLocalUrl(userModel.ReturnUrl))
				{
					return Redirect(userModel.ReturnUrl);
				}
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
			return View(userModel);
		}
		#endregion

		public async  Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public IActionResult AccessDenied() => new StatusCodeResult(500);
	}
}
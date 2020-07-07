using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
	public class HomeController : Controller
	{		
		public IActionResult Index() => View();
		public IActionResult Blogs() => View();
		public IActionResult Cart() => View();
		public IActionResult ShopBlog() => View();
		public IActionResult Checkout() => View();
		public IActionResult Contacts() => View();
		public IActionResult Login() => View();
		public IActionResult ProductDetails() => View();		
	}
}
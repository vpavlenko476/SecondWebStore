using Microsoft.AspNetCore.Mvc;
using Store.ServicesHosting.Abstract;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IValueService _service;

		public HomeController(IValueService service)
		{
			this._service = service;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _service.GetAsync();
			return View(values);
		}
		public IActionResult Blogs() => View();		
		public IActionResult ShopBlog() => View();
		public IActionResult Checkout() => View();
		public IActionResult Contacts() => View();
		public IActionResult Login() => View();
		public IActionResult ProductDetails() => View();		
	}
}
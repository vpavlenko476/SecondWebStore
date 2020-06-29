using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.DAL.Contracts;
using Store.Domain;
using Store.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBaseRepo<EmployeeEntity> _employeeRepo;
		private readonly IMapper _mapper;
		public HomeController(IBaseRepo<EmployeeEntity> repo, IMapper mapper)
		{
			_employeeRepo = repo;
			_mapper = mapper;
		}		
		
		public IActionResult Index() => View();
		public IActionResult Blogs() => View();
		public IActionResult Cart() => View();
		public IActionResult ShopBlog() => View();
		public IActionResult Checkout() => View();
		public IActionResult Contacts() => View();
		public IActionResult Login() => View();
		public IActionResult ProductDetails() => View();
		public IActionResult Shop() => View();
	}
}
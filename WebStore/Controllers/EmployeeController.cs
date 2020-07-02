using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Services.Abstract;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;		
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}
		public IActionResult Index() => View(_employeeService.GetAll());

		public async Task<IActionResult> DetailsAsync(int id)
		{			
			return View(await _employeeService.GetById(id));
		}

		[HttpGet]
		public async Task<IActionResult> EditAsync(int id)
		{
			var employee = await _employeeService.GetById(id);
			return View(employee);
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(Employee employee)
		{
			if (ModelState.IsValid)
			{
				await _employeeService.Edit(employee);
			}
			return View("Index", _employeeService.GetAll());
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await _employeeService.Delete(id);
			return View("Index", _employeeService.GetAll());
		}
	}
}
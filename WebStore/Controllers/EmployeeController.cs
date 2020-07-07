using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Services.Abstract;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;
		private readonly IMapper _mapper;
		public EmployeeController(IEmployeeService employeeService, IMapper mapper)
		{
			_employeeService = employeeService;
			_mapper = mapper;
		}
		public IActionResult Index() => View(_employeeService.GetAll());

		public async Task<IActionResult> DetailsAsync(int id)
		{			
			return View(await _employeeService.GetById(id));
		}

		[HttpGet]
		public async Task<IActionResult> EditAsync(int? id)
		{
			if (id == null) return View(new EmployeeViewModel());

			if (id < 0) return BadRequest();

			var employee = await _employeeService.GetById(id.GetValueOrDefault());
			if (employee == null) return NotFound();
			return View(_mapper.Map<EmployeeViewModel>(employee));			
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(EmployeeViewModel employeeVM)
		{
			if (employeeVM.FirstName == "QWE")
				ModelState.AddModelError(nameof(employeeVM.FirstName), "Странное имя");
			if (ModelState.IsValid)
			{
				await _employeeService.Edit(_mapper.Map<Employee>(employeeVM));
			}
			else
			{
				return View(employeeVM);
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0) return BadRequest();
			var employee = await _employeeService.GetById(id);			
			return View(_mapper.Map<EmployeeViewModel>(employee));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmedAsync(int id)
		{
			await _employeeService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
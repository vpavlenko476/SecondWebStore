using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.DAL.Contracts;
using Store.Domain;
using Store.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IBaseRepo<EmployeeEntity> _employeeRepo;
		private readonly IMapper _mapper;
		public EmployeeController(IBaseRepo<EmployeeEntity> repo, IMapper mapper)
		{
			_employeeRepo = repo;
			_mapper = mapper;
		}
		public IActionResult Index() => View(_mapper.Map<IList<Employee>>(_employeeRepo.GetAll()));

		public async Task<IActionResult> Details(int id)
		{
			var employee = _mapper.Map<Employee>(await _employeeRepo.GetOne(id));
			return View(employee);
		}

		[HttpGet]
		public async Task<IActionResult> EditAsync(int id)
		{
			var employee = _mapper.Map<Employee>(await _employeeRepo.GetOne(id));
			return View(employee);
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(Employee employee)
		{
			if (ModelState.IsValid)
			{
				var editedEmployee = _mapper.Map<EmployeeEntity>(employee);
				await _employeeRepo.Update(editedEmployee);
			}
			return View("Index", _mapper.Map<IList<Employee>>(_employeeRepo.GetAll()));
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var employeeToDelete = await _employeeRepo.GetOne(id);
			await _employeeRepo.Delete(employeeToDelete);
			return View("Index", _mapper.Map<IList<Employee>>(_employeeRepo.GetAll()));
		}
	}
}
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
	}
}
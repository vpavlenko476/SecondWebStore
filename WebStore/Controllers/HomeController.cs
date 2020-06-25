using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using System.Collections.Generic;
using System.Linq;

namespace WebStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly List<Employee> employees = new List<Employee>()
		{
			new Employee(){Id=0, FirstName="Name0", SecondName="SecondName0", Patronymic="Patronymic0", Age="22", Email="test0@email.ru", MobilePhone="+7(999)000-00-00"},
			new Employee(){Id=1, FirstName="Name1", SecondName="SecondName1", Patronymic="Patronymic1", Age="22", Email="test1@email.ru", MobilePhone="+7(999)000-00-01"},
			new Employee(){Id=2, FirstName="Name2", SecondName="SecondName2", Patronymic="Patronymic2", Age="22", Email="test2@email.ru", MobilePhone="+7(999)000-00-02"}
		};

		public IActionResult Index() => View(employees);
		public IActionResult Employees() => View(employees);

		public IActionResult EmployeeInfo(int id)
		{
			return View(employees.Where(e=>e.Id==id).Single());
		}
	}
}
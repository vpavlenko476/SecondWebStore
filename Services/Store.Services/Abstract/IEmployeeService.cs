using Store.Domain;
using Store.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
	/// <summary>
	/// Сервис взаимодействия с сотрудниками
	/// </summary>
	public interface IEmployeeService
	{
		/// <summary>
		/// Редактирование
		/// </summary>		
		Task Edit(Employee employee);

		/// <summary>
		/// Удаление
		/// </summary>		
		Task Delete(int employeeId);

		/// <summary>
		/// Добавление
		/// </summary>		
		Task<int> Add(Employee employee);

		/// <summary>
		/// Получить список всех сотрудников
		/// </summary>		
		IEnumerable<Employee> GetAll();

		/// <summary>
		/// Получить сотрудника по его идентификатору
		/// </summary>		
		Task<Employee> GetById(int id);		
	}
}

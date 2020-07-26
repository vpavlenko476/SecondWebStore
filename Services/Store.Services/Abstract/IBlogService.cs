using Store.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
	interface IBlogService
	{
		/// <summary>
		/// Редактирование блога
		/// </summary>		
		Task Edit(Blog employee);

		/// <summary>
		/// Удаление блога
		/// </summary>		
		Task Delete(int employeeId);

		/// <summary>
		/// Добавление блога
		/// </summary>		
		Task<int> Add(Blog employee);

		/// <summary>
		/// Получить список всех блогов
		/// </summary>		
		IQueryable<Blog> GetAll();		
	}
}

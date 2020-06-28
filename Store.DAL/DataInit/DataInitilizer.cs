using Microsoft.EntityFrameworkCore;
using Store.DAL.Context;
using Store.Entities;
using System.Collections.Generic;

namespace Store.DAL.DataInit
{
	public static class DataInitilizer
	{
		public static void InitData()
		{
			List<EmployeeEntity> employees = new List<EmployeeEntity>()
		{
			new EmployeeEntity(){FirstName="Name0", SecondName="SecondName0", Patronymic="Patronymic0", Age=22, Email="test0@email.ru", MobilePhone="+7(999)000-00-00"},
			new EmployeeEntity(){FirstName="Name1", SecondName="SecondName1", Patronymic="Patronymic1", Age=22, Email="test1@email.ru", MobilePhone="+7(999)000-00-01"},
			new EmployeeEntity(){FirstName="Name2", SecondName="SecondName2", Patronymic="Patronymic2", Age=22, Email="test2@email.ru", MobilePhone="+7(999)000-00-02"}
		};
			var context = new StoreContext();
			context.Employees.AddRange(employees);
			context.SaveChanges();
		}

		/// <summary>
		/// Удаление и восстановление БД начальными значениями
		/// </summary>		
		public static void RecreateDatabase(StoreContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.Migrate();
		}
	}
}

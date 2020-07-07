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

			List<SectionEntity> sections = new List<SectionEntity>
			{
				new SectionEntity(){Order = 0, ParentId = null, Name = "Спорт", Id = 1},
				new SectionEntity(){Order = 0, ParentId = 1, Name = "Nike", Id = 2},
				new SectionEntity(){Order = 1, ParentId = 1, Name = "Under Armor", Id = 3},
				new SectionEntity(){Order = 2, ParentId = 1, Name = "Adidas", Id = 4},
				new SectionEntity(){Order = 3, ParentId = null, Name = "Puma", Id = 5},
				new SectionEntity(){Order = 0, ParentId = null, Name = "Для мужчие", Id =6},
				new SectionEntity(){Order = 0, ParentId = 6, Name = "Fendi", Id = 7}
			};			
			context.Sections.AddRange(sections);

			List<BrandEntity> brands = new List<BrandEntity>()
			{
				new BrandEntity(){Order = 0, Name = "Acne"},
				new BrandEntity(){Order = 1, Name = "Grune Erde"},
				new BrandEntity(){Order = 2, Name = "Albiro"},
				new BrandEntity(){Order = 3, Name = "Ronhill"},
				new BrandEntity(){Order = 4, Name = "Oddmolly"},
				new BrandEntity(){Order = 5, Name = "Boudestijn"},
				new BrandEntity(){Order = 6, Name = "Rosch creative culture"}
			};
			context.Brands.AddRange(brands);
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

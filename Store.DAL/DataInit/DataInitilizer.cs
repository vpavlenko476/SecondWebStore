using Microsoft.EntityFrameworkCore;
using Store.DAL.Context;
using Store.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.DAL.DataInit
{
	public class DataInitilizer
	{
		private readonly StoreContext _context;
		public DataInitilizer(StoreContext context)
		{
			_context = context;
		}
		public void InitData()
		{
			var db = _context.Database;
			db.Migrate();

			if (_context.Products.Any()) return;

			using(db.BeginTransaction())
			{
				_context.Employees.AddRange(TestData.Employees);				
				_context.SaveChanges();				
				db.CommitTransaction();
			}

			using (db.BeginTransaction())
			{
				_context.Sections.AddRange(TestData.Sections);
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
				_context.SaveChanges();
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");
				db.CommitTransaction();
			}

			using (db.BeginTransaction())
			{
				_context.Brands.AddRange(TestData.Brands);
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
				_context.SaveChanges();
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");
				db.CommitTransaction();
			}

			using (db.BeginTransaction())
			{
				_context.Products.AddRange(TestData.Products);
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
				_context.SaveChanges();
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
				db.CommitTransaction();
			}

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

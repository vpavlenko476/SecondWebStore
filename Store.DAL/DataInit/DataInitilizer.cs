using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Store.DAL.Context;
using Store.Entities;
using Store.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Store.DAL.DataInit
{
	public class DataInitilizer
	{
		private readonly StoreContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		public DataInitilizer(StoreContext context)
		{
			_context = context;
		}
		public void InitData()
		{
			var db = _context.Database;
			db.Migrate();

			if (_context.Products.Any()) return;

			using (db.BeginTransaction())
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

			using (db.BeginTransaction())
			{
				_context.Blogs.AddRange(TestData.Blogs);
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] ON");
				_context.SaveChanges();
				db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Blogs] OFF");
				db.CommitTransaction();
			}

			//var products = TestData.Products;
			//var sections = TestData.Sections;
			//var brands = TestData.Brands;
			//var prosuct_sections = products.Join(
			//	sections, 
			//	p => p.SectionId, 
			//	s => s.Id, 
			//	(product,section)=>(product,section));

			//foreach(var (product, section) in prosuct_sections)
			//{
			//	product.Section = section;
			//	product.SectionId = 0;
			//}

			//var prosuct_brands = products.Join(
			//	brands,
			//	p => p.BrandId,
			//	s => s.Id,
			//	(product, brand) => (product, brand));

			//foreach (var (product, brand) in prosuct_brands)
			//{
			//	product.Brand = brand;
			//	product.BrandId = null;
			//}

			//var child_sections = sections.Join(
			//	sections,
			//	child => child.ParentId,
			//	parrent => parrent.Id,
			//	(child, parrent) => (child, parrent));

			//foreach (var (child, parrent) in child_sections)
			//{
			//	child.ParentSection = parrent;
			//	child.ParentId = null;
			//}

			//foreach (var section in sections)
			//	section.Id = 0;

			//foreach (var brand in brands)
			//	brand.Id = 0;

			//using(db.BeginTransaction())
			//{
			//	_context.Sections.AddRange(sections);
			//	_context.Brands.AddRange(brands);
			//	_context.Products.AddRange(products);
			//	_context.SaveChanges();
			//	db.CommitTransaction();
			//}
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

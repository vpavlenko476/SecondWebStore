using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Store.DAL.Context;
using Store.Entities;
using Store.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DAL.DataInit
{
	public class DataInitilizer
	{
		private readonly StoreContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		public DataInitilizer(StoreContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
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

				_context.SaveChanges();

				db.CommitTransaction();
			}

			InitIdentityAsync().Wait();			
		}

		private async Task InitIdentityAsync()
		{
			await CheckRoleExist(Role.Administrator);
			await CheckRoleExist(Role.User);

			if (await _userManager.FindByNameAsync(User.Administrator) is null)
			{
				var admin = new User() { UserName = User.Administrator };
				var creationResult = await _userManager.CreateAsync(admin, User.DeafaultAdminPass);
				if (creationResult.Succeeded)
				{
					await _userManager.AddToRoleAsync(admin, Role.Administrator);
				}
				else
				{
					var errors = creationResult.Errors;
					throw new InvalidOperationException($"Ошибка при создании пользователя Администратор: {string.Join(",", errors)}");
				}
			}

			async Task CheckRoleExist(string RoleName)
			{
				if (!await _roleManager.RoleExistsAsync(RoleName))
				{
					await _roleManager.CreateAsync(new Role() { Name = RoleName });
				}
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

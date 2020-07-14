using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Entities;
using Store.Entities.Identity;

namespace Store.DAL.Context
{
	public class StoreContext: IdentityDbContext<User, Role, string>
	{
		internal StoreContext() {}
		public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
		public DbSet<EmployeeEntity> Employees { get; set; }
		public DbSet<SectionEntity> Sections { get; set; }
		public DbSet<BrandEntity> Brands { get; set; }
		public DbSet<ProdctEntity> Products { get; set; }
		public DbSet<BlogEntity> Blogs { get; set; }

		/// <summary>
		/// Выполняется если вызван конструктор без параметров
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = @"server=(localdb)\MSSQLLocalDB;Database=WebStore;integrated security=True;MultipleActiveResultSets=true;App=EntityFramework";
				optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
			}
		}
	}
}

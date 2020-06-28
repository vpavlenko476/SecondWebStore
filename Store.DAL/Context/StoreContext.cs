using Microsoft.EntityFrameworkCore;
using Store.Entities;

namespace Store.DAL.Context
{
	public class StoreContext: DbContext
	{
		internal StoreContext() {}
		public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
		public DbSet<EmployeeEntity> Employees { get; set; }

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

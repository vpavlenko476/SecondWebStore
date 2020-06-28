﻿
using Microsoft.EntityFrameworkCore;
using Store.Domain;

namespace Store.DAL.Context
{
	class StoreContext: DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }
	}
}
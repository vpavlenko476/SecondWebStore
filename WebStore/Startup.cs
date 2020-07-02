using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.DAL.Context;
using Store.DAL.Contracts;
using Store.DAL.Repositories;
using Store.Entities;
using Store.Services;
using Store.Services.Abstract;
using WebStore.Infrastructure.Middleware;

namespace WebStore
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews(opt =>
			{
				//opt.Filters.Add<Filter>(); добавление фильтров				
				//opt.Conventions.Add() добавление соглашений
			}
				).AddRazorRuntimeCompilation();
			services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration["Data:Store:ConnectionString"])); ;
			services.AddScoped<IBaseRepo<EmployeeEntity>, BaseRepo<EmployeeEntity>>();
			services.AddAutoMapper(typeof(Startup));
			services.AddTransient<IEmployeeService, EmployeeService>();
		}

		//настройка конвейера middleware
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();
			app.UseDefaultFiles();
			app.UseRouting();
			app.Use(async (context, next) =>
			{
				//действие над контекстом до
				await next();//вызов следйющего middleware
				//действие над контекстом после
			});
			app.UseMiddleware<TestMiddleware>(); //использование кастомного middleware
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}

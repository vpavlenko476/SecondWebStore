using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.DAL;
using Store.DAL.Context;
using Store.DAL.DataInit;
using Store.Entities.Identity;
using Store.Services;
using Store.Services.Abstract;
using Store.Services.InCookies;
using System;
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
			
			//добавляем систему Identity
			services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<StoreContext>()
				.AddDefaultTokenProviders();

			//конфигурация Identity
			services.Configure<IdentityOptions>(opt =>
			{
#if DEBUG
				opt.Password.RequiredLength = 4;
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredUniqueChars = 3;

#endif
				opt.User.RequireUniqueEmail = false;

				//все новые пользователи должны быть разблокированы
				opt.Lockout.AllowedForNewUsers = true;
				opt.Lockout.MaxFailedAccessAttempts = 10;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

			});

			//настройка cookie для Identity
			services.ConfigureApplicationCookie(opt =>
			{
				opt.Cookie.Name = "WebStorePerProj";
				opt.Cookie.HttpOnly = true;
				opt.ExpireTimeSpan = TimeSpan.FromDays(10);

				opt.LoginPath = "/Account/Login";
				opt.LogoutPath = "/Account/Logout";
				opt.AccessDeniedPath = "/Account/AccessDenied";

				//автоматическая смена идентификатора сессии при авторизации
				opt.SlidingExpiration = true;
			});

			services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration["Data:Store:ConnectionString"]));
			services.AddTransient<DataInitilizer>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<StoreUnitOfWork>();
			services.AddScoped<IProductService, ProductService>();
			services.AddAutoMapper(typeof(Startup));
			services.AddTransient<IEmployeeService, EmployeeService>();
		}

		//настройка конвейера middleware
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataInitilizer dbInit)
		{
			dbInit.InitData();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			app.UseStaticFiles();
			app.UseDefaultFiles();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();
			
			//app.Use(async (context, next) =>
			//{
			//	//действие над контекстом до
			//	await next();//вызов следйющего middleware
			//	//действие над контекстом после
			//});
			app.UseMiddleware<TestMiddleware>(); //использование кастомного middleware
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "areas ",
					areaName: "Admin",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}

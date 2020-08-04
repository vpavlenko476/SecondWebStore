using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.DAL;
using Store.DAL.Context;
using Store.DAL.DataInit;
using Store.Services;
using Store.Services.Abstract;
using Store.Services.InCookies;
using Store.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Store.Clients;

namespace Store.ServicesHosting
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration["Data:Store:ConnectionString"]));
			services.AddTransient<DataInitilizer>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<StoreUnitOfWork>();

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

			services.AddTransient<IOrderService, OrderService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddAutoMapper(typeof(Startup));
			services.AddTransient<IEmployeeService, EmployeeService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

﻿
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middleware
{
	public class TestMiddleware
	{
		private readonly RequestDelegate _next;
		public TestMiddleware(RequestDelegate next) => _next = next;
		public async Task Invoke(HttpContext context)
		{
			await _next(context);
		}
	}
}

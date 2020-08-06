using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Entities;
using Store.Services.Abstract;
using Store.ViewModels;

namespace Store.ServicesHosting.Controllers
{
	[Route("api/orders")]
	[Produces("application/json")]
	public class OrderApiController : ControllerBase, IOrderService
	{
		private readonly IOrderService _orderService;

		public OrderApiController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost, ActionName("Post")]
		public Task<Order> CreateOrder([FromBody]CartOrderViewModel cartOrderViewModel)
		{
			return _orderService.CreateOrder(cartOrderViewModel);
		}

		[HttpGet("{id}")]
		public Task<Order> GetOrderById(int id)
		{
			return _orderService.GetOrderById(id);
		}

		[HttpGet("{userName}")]
		public Task<IEnumerable<Order>> GetOrders(string userName)
		{
			return _orderService.GetOrders(userName);
		}
	}
}

using Microsoft.Extensions.Configuration;
using Store.Domain;
using Store.Services.Abstract;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Store.Clients
{
	public class OrderClient: BaseClient, IOrderService
	{
		protected override string ServiceAddress { get; } = "api/orders";
		public OrderClient(IConfiguration configuration) : base(configuration)
		{

		}

		public async Task<IEnumerable<Order>> GetOrders(string userName)
		{
			return await GetAsync<List<Order>>($"{ServiceAddress}/{userName}");
		}

		public Task<Order> GetOrderById(int id)
		{
			return GetAsync<Order>($"{ServiceAddress}/{id}");
		}

		public async Task<Order> CreateOrder(CartOrderViewModel cartOrderViewModel)
		{
			var response = await PostAsync(ServiceAddress, cartOrderViewModel);
			var result = response.Content.ReadAsAsync<Order>().Result;
			return result;
		}
	}
}

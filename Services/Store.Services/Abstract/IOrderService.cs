using Store.Domain;
using Store.Entities;
using Store.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetOrders(string userName);
		Task<Order> GetOrderById(int id);
		Task<Order> CreateOrder(CartOrderViewModel cartOrderViewModel);
	}
}

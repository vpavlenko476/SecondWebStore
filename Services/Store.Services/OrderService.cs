using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.DAL.Context;
using Store.Domain;
using Store.Entities;
using Store.Entities.Identity;
using Store.Services.Abstract;
using Store.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Store.Services
{
	public class OrderService : IOrderService
	{
		private readonly StoreUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly StoreContext _storeContext;
		private readonly IProductService _productService;
		private readonly UserManager<User> _userManager;

		public OrderService(StoreUnitOfWork unitOfWork, IMapper mapper, StoreContext storeContext, UserManager<User> userManager, IProductService productService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_storeContext = storeContext;
			_productService = productService;
		}

		public async Task<Order> CreateOrder(string userName, CartViewModel cart, OrderViewModel orderVM)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user is null) throw new InvalidOperationException($"Пользователь {userName} не найден");

			await using var transaction = await _storeContext.Database.BeginTransactionAsync();
			var order = new Order
			{
				Address = orderVM.Address,
				Phone = orderVM.Phone,
				User = user,
				Date = DateTime.Now
			};

			foreach(var (product, quantity) in cart.Items)
			{
				var prod = await _productService.GetProductByIdAsync(product.Id);
				if (prod is null) continue;

				var order_item = new OrderItem()
				{
					Order = order,
					Price = prod.Price,
					Product = prod,
					Quantity = quantity,
				};
				order.Items.Add(order_item);
			}

			await _unitOfWork.OrderRepository.Add(_mapper.Map<OrderEntity>(order));
			await transaction.CommitAsync();
			return order;
		}

		public async Task<Order> GetOrderById(int id)
		{
			var order = await _storeContext.Orders
							.Include(order => order.User)
							.SingleAsync(order => order.Id == id);
			return _mapper.Map<Order>(order);
		}

		public async Task<IEnumerable<Order>> GetOrders(string userName)
		{
			var orders = await _storeContext.Orders
											.Include(order => order.User)
											.Include(order => order.Items)
											.Where(order => order.Name == userName)
											.ToArrayAsync();
			return _mapper.Map<List<Order>>(orders);
		}
	}
}

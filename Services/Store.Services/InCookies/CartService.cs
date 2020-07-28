using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Store.Domain.CartModel;
using Store.Services.Abstract;
using Store.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services.InCookies
{
	public class CartService : ICartService
	{
		private readonly IProductService _productService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
		private readonly string _cartName;
		private Cart cart 
		{
			get
			{
				var context = _httpContextAccessor.HttpContext;
				var cookie = context.Response.Cookies;
				var cartCookie = context.Request.Cookies[_cartName];//cookie хранения корзины
				if(cartCookie is null)
				{
					var cart = new Cart();
					cookie.Append(_cartName, JsonConvert.SerializeObject(cart));
					return cart;
				}

				ReplaceCookies(cookie, cartCookie);
				return JsonConvert.DeserializeObject<Cart>(cartCookie);
			}
			set
			{
				ReplaceCookies(_httpContextAccessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
			}
		}
		public CartService(IProductService productService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			_productService = productService;
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;

			var user = httpContextAccessor.HttpContext.User;
			var userName = user.Identity.IsAuthenticated ? user.Identity.Name : null;//проверка что пользователь вошел в систему
			_cartName = $"WebStore.Cart{userName}";
		}		

		public void AddToCart(int id)
		{
			var cart = this.cart;
			var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
			if(item is null)
			{
				cart.Items.Add(new CartItem() { ProductId = id, Count = 1 });
			}
			else
			{
				item.Count++;
			}
			this.cart = cart;
		}

		public void Clear()
		{
			var cart = this.cart;
			cart.Items.Clear();
			this.cart = cart;
		}

		public void DecrementFromCart(int id)
		{
			var cart = this.cart;
			var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
			if (item is null) return;
			if (item.Count !=0 )
			{
				item.Count--;
			}
			if(item.Count == 0)
			{
				cart.Items.Remove(item);
			}
			this.cart = cart;
		}

		public CartViewModel GetCartModel()
		{
			var product = _productService.GetProducts(null, null, cart.Items.Select(i=>i.ProductId).ToArray());
			var productVM = _mapper.Map<IEnumerable<ProductViewModel>>(product).ToDictionary(p => p.Id);
			return new CartViewModel()
			{
				Items = cart.Items.Select(item => (productVM[item.ProductId], item.Count))
			};
		}

		public void RemoveFromCart(int id)
		{
			var cart = this.cart;
			var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
			if (item is null) return;
			cart.Items.Remove(item);
			this.cart = cart;
		}
		private void ReplaceCookies(IResponseCookies cookies, string cookie)
		{
			cookies.Delete(_cartName);
			cookies.Append(_cartName, cookie);
		}
	}
}

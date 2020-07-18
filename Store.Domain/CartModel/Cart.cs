using Store.Domain.CartModel;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.CartModel
{
	public class Cart
	{
		public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

		public int ItemsCount => Items?.Sum(x => x.Count) ?? 0;
	}
}

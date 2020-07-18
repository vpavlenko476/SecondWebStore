using System.Collections.Generic;
using System.Linq;

namespace Store.ViewModels
{
	public class CartViewModel
	{
		public IEnumerable<(ProductViewModel productVM, int Count)> Items { get; set; }
		public int ItemsCount => Items?.Sum(i => i.Count) ?? 0;
		public double TotalPrice => Items?.Sum(i =>i.Count*i.productVM.Price) ?? 0;			
	}
}

using Store.Entities;

namespace Store.ViewModels
{
	public class CartOrderViewModel
	{
		public CartViewModel Cart { get; set; }
		public OrderViewModel Order { get; set; }
	}
}

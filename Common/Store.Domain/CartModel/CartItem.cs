namespace Store.Domain.CartModel
{
	public class CartItem
	{
		/// <summary>
		/// Идентификатор товара
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// Количество товара в корзине
		/// </summary>
		public int Count { get; set; }
	}
}

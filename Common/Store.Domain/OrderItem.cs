namespace Store.Domain
{
	public class OrderItem
	{
		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
	}
}

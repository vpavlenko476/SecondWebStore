namespace Store.Domain
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public int SectionId { get; set; }
		public int? BrandId { get; set; }
		public Brand Brand { get; set; }
		public string ImageUrl { get; set; }
		public double Price { get; set; }
	}
}

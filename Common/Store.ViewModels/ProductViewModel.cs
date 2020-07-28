using Store.Domain;
using Store.Entities.Abstract;

namespace Store.ViewModels
{
	public class ProductViewModel: INamedEntity, IOrderedEntity
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public int Order { get; set; }
		public string ImageUrl { get; set; }
		public double Price { get; set; }
		public Brand Brand { get; set; }
	}
}

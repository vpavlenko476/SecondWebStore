using Store.Entities.Abstract;
using Store.Entities.Base;

namespace Store.Entities
{
	public class ProdctEntity : BaseNamedEntity, IOrderedEntity
	{	
		public int Order { get; set; }
		public int SectionId { get; set; }
		public int? BrandId { get; set; }
		public string ImageUrl { get; set; }
		public double Price { get; set; }
	}
}

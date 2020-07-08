using Store.Entities.Abstract;
using Store.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities
{
	[Table("Products")]
	public class ProdctEntity : BaseNamedEntity, IOrderedEntity
	{	
		public int Order { get; set; }
		public int SectionId { get; set; }

		[ForeignKey(nameof(SectionId))]
		public virtual SectionEntity Section { get; set; }
		public int? BrandId { get; set; }

		[ForeignKey(nameof(BrandId))]
		public virtual BrandEntity Brand { get; set; }
		public string ImageUrl { get; set; }

		[Column(TypeName = "double")]
		public double Price { get; set; }
	}
}

using Store.Entities.Abstract;
using Store.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities
{
	[Table("ProductSections")]
	public class SectionEntity : BaseNamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int? ParentId { get; set; }

		[ForeignKey(nameof(ParentId))]
		public virtual SectionEntity ParentSection { get; set; }
		public virtual ICollection<ProdctEntity> Products { get; set; } = new List<ProdctEntity>();
	}
}

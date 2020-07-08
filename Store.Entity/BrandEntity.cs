using Store.Entities.Abstract;
using Store.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities
{
	[Table("ProductBrands")]
	public class BrandEntity : BaseNamedEntity, IOrderedEntity
	{
		public int Order { get; set; }

		/// <summary>
		/// Навигацинное свойство (один ко многим)
		/// </summary>
		public virtual ICollection<ProdctEntity> Products { get; set; } = new List<ProdctEntity>();
	}
}

using Store.Entity;
using System.ComponentModel.DataAnnotations;

namespace Store.Entities.Order
{
	public class OrderItemEntity: BaseEntity
	{
		[Required]
		public virtual OrderEntity Order { get; set; }
		public virtual ProdctEntity Product { get; set; }
		public double Price { get; set; } 
	}
}

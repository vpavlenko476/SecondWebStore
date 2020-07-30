using Store.Entities.Base;
using Store.Entities.Identity;
using Store.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Entities
{
	public class OrderEntity : BaseNamedEntity
	{
		[Required]
		public virtual User user { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public DateTime Date { get; set; }
		public virtual ICollection<OrderItemEntity> Items { get; set; }
	}
}

using Store.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Store.Domain
{
	public class Order
	{
		public virtual User User { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public DateTime Date { get; set; }
		public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
	}
}

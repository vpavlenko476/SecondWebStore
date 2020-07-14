using Store.Entities.Identity;
using Store.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities
{
	public class BlogEntity: BaseEntity
	{
		[Column(TypeName = "Author")]
		public User Author { get; set; }
		
		public DateTime AddTime { get; set; }

		[StringLength(50)]
		public string Topic { get; set; }
		public string Body { get; set; }
	}
}

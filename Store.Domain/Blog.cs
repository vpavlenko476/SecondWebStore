using Store.Entities.Identity;
using System;

namespace Store.Domain
{
	class Blog
	{
		public int Id { get; set; }		
		public User Author { get; set; }
		public DateTime AddTime { get; set; }	
		public string Topic { get; set; }
		public string Body { get; set; }
	}
}

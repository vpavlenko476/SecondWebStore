using System.ComponentModel.DataAnnotations;

namespace Store.Entity
{
	public class BaseEntity
	{
		[Key]
		public int Id {get;set;}
	}
}

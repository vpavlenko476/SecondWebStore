using Store.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity
{
	public class BaseEntity: IEntity
	{
		[Key]
		public int Id {get;set;}
	}
}

using Store.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entity
{
	public class BaseEntity: IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {get;set;}
	}
}

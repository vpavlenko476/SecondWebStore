using Store.Entities.Abstract;
using Store.Entity;
using System.ComponentModel.DataAnnotations;

namespace Store.Entities.Base
{
	public class BaseNamedEntity : BaseEntity, INamedEntity
	{
		[Required]
		public string Name { get; set; }
	}
}

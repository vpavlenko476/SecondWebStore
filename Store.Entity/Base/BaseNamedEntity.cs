using Store.Entities.Abstract;
using Store.Entity;

namespace Store.Entities.Base
{
	class BaseNamedEntity : BaseEntity, INamedEntity
	{
		public string Name { get; set; }
	}
}

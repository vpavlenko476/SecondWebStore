using Store.Entities.Abstract;
using Store.Entities.Base;

namespace Store.Entities
{
	class BrandEntity : BaseNamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
	}
}

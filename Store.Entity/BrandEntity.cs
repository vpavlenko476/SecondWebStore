using Store.Entities.Abstract;
using Store.Entities.Base;

namespace Store.Entities
{
	public class BrandEntity : BaseNamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
	}
}

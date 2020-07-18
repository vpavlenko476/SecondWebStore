using Store.Entities.Abstract;

namespace Store.ViewModels
{
	public class BrandViewModel : IOrderedEntity, INamedEntity
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public int Order { get; set; }
	}
}

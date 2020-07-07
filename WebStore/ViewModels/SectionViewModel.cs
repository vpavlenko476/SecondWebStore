using Store.Entities.Abstract;
using System.Collections.Generic;

namespace WebStore.ViewModels
{
	public class SectionViewModel : INamedEntity, IOrderedEntity
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public int Order { get; set; }
		public List<SectionViewModel> ChildSections { get; set; } = new List<SectionViewModel>();
		public SectionViewModel ParrentSection { get; set; }
	}
}

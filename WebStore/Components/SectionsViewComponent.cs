using Microsoft.AspNetCore.Mvc;
using Store.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Components
{
	public class SectionsViewComponent : ViewComponent
	{
		private readonly StoreUnitOfWork _unitOfWork;
		public SectionsViewComponent(StoreUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IViewComponentResult> Invoke() => View();

		private IEnumerable<SectionViewModel> GetSections()
		{
			var sections = _unitOfWork.SectionRepository.GetAll();			
			var parentSectionView = sections
				.Where(s => s.ParentId == null)
				.Select(s => new SectionViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					Order = s.Order
				});
			foreach(var parentSection in parentSectionView)
			{
				var childSections = sections.Where(s => s.ParentId == parentSection.Id);
				foreach(var childSection in childSections)
				{
					parentSection.ChildSections.Add(new SectionViewModel()
					{
						Id = childSection.Id,
						Name = childSection.Name,
						ParrentSection = parentSection,
						Order = childSection.Order
					});
				}
				parentSection.ChildSections.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
			}
			parentSectionView.ToList().Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
			return parentSectionView;
		}
	}
}

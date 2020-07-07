using Microsoft.AspNetCore.Mvc;
using Store.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Components
{
	public class BrandsViewComponent: ViewComponent
	{
		private readonly StoreUnitOfWork _unitOfWork;
		public BrandsViewComponent(StoreUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IViewComponentResult Invoke() => View(GetBrands());
		public IEnumerable<BrandViewModel> GetBrands()
		{
			return _unitOfWork.BrandRepository.GetAll()
				.Select(b => new BrandViewModel()
				{
					Id = b.Id,
					Name = b.Name,
					Order = b.Order
				})
				.OrderBy(b => b.Order);
		}
	}
}

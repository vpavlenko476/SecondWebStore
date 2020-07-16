using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
	public class CatalogController : Controller
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public CatalogController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		public IActionResult Shop(int? sectionId, int? brandId)
		{
			var products = _productService.GetProducts(sectionId, brandId);
			return View(new CatalogViewModel()
			{
				SectionId = sectionId,
				BrandId = brandId,
				Products = products.Select(p => _mapper.Map<ProductViewModel>(p)).OrderBy(p => p.Order),
			});
		}

		public async Task<IActionResult> Details(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			if(product is null)
			{
				return NotFound();
			}

			return View(_mapper.Map<ProductViewModel>(product));
		}
	}
}
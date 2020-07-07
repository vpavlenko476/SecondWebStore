using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Services.Abstract;
using System.Linq;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;
        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Shop(int? sectionId, int? brandId)
        {
            var products = _productService.GetProducts(sectionId, brandId);
            return View(new CatalogViewModel() 
            {
                SectionId = sectionId,
                BrandId = brandId,
                Products = products.Select(p=>new ProductViewModel() 
                {
                    Name = p.Name,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p=>p.Order),
            });
        }
    }
}
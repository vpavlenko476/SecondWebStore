using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Entities.Identity;
using Store.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=Role.Administrator)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_mapper.Map<List<Product>>(_productService.GetProducts()));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {            
            return RedirectToAction(nameof(Index));
        }

    }
}
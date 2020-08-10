using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Services.Abstract;

namespace Store.ServicesHosting.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductApiController : ControllerBase, IProductService
	{
		private readonly IProductService _productService;

		public ProductApiController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("{id}"), ActionName("Get")]
		public Task<Product> GetProductByIdAsync(int id)
		{
			return _productService.GetProductByIdAsync(id);
		}

		[HttpPost, ActionName("Post")]
		public IEnumerable<Product> GetProducts([FromBody]ProductFilter filter)
		{
			return _productService.GetProducts(filter);
		}
	}
}
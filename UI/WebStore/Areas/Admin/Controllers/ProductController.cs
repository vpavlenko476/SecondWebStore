using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Entities.Identity;
using Store.Services.Abstract;
using System.Collections.Generic;

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
    }
}
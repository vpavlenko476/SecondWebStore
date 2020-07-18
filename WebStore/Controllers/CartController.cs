using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Abstract;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {            
            _cartService = cartService;
        }

        public IActionResult Details() => View(_cartService.GetCartModel());
        
    }
}
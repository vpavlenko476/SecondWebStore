using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Services.Abstract;
using Store.ViewModels;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {            
            _cartService = cartService;
        }

        public IActionResult Details() => View(new CartOrderViewModel { Cart = _cartService.GetCartModel()});
        
        public IActionResult AddToCart(int id)
        {
            _cartService.AddToCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult Clear()
        {
            _cartService.Clear();
            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> CheckOut(OrderViewModel orderModel, [FromServices] IOrderService orderService)
        {
            if(!ModelState.IsValid)
            {
                return View(nameof(Details), new CartOrderViewModel 
                {
                    Cart = _cartService.GetCartModel(),
                    Order = orderModel
                });
            }
            var order = orderService.CreateOrder(User.Identity.Name, _cartService.GetCartModel(), orderModel);
            _cartService.Clear();
            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id });
        }

        public IActionResult OrderConfirmed (int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}
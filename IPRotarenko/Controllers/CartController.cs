using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.ViewModels;
using IPRotarenko.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace IPRotarenko.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }
        public IActionResult Details()
        {
            return View(new CartOrderViewModel
            {
                CartViewModel = _CartService.TransformFromCart(),
                OrderViewModel = new OrderViewModel()
            }
            ) ;
        }
        public IActionResult AddToCart(int Id)
        {
            _CartService.AddToCart(Id);
           
            return new NoContentResult();
        }
        public IActionResult DecrementFromCart(int Id, decimal count)
        {
            _CartService.DecrementFromCart(Id, count);
            return RedirectToAction(nameof(Details));

        }
        public IActionResult AddFromCart(int Id, decimal count)
        {
            _CartService.AddFromCart(Id, count);
            return RedirectToAction(nameof(Details));

        }
        public IActionResult RemoveFromCart(int Id)
        {
            _CartService.RemoveFromCart(Id);
            return RedirectToAction(nameof(Details));

        }
        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction(nameof(Details));

        }
        public IActionResult CheckOut(OrderViewModel Model, [FromServices] IOrderService OrderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new CartOrderViewModel 
                {
                    CartViewModel = _CartService.TransformFromCart(),
                    OrderViewModel = Model
                });
            var order = OrderService.CreateOrder(_CartService.TransformFromCart(), Model);
            _CartService.RemoveAll();
            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id});
        }
        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();

        }
    }
}
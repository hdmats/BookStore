using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository repo { get; set; }
        private Basket basket { get; set; }

        public CartController (ICartRepository temp, Basket bt)
        {
            repo = temp;
            basket = bt;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Cart());
        }

        [HttpPost]
        public IActionResult Checkout(Cart cart)
        {
            if (basket.Items.Count() ==0)
            {
                ModelState.AddModelError("", "Sorry, your basket it empty!");
                return View();
            }
            if (ModelState.IsValid)
            {
                cart.Lines = basket.Items.ToArray();
                repo.SaveCart(cart);
                basket.ClearBasket();
                return RedirectToPage("/CheckoutCompleted");
            }
            else {
                return View();
            }
        }
    }
}

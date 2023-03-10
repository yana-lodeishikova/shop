using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {


        private readonly IAllOrder allorder;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrder AllOrder, ShopCart shopCart) {
            this.allorder = AllOrder;
            this.shopCart = shopCart;

        }

        public IActionResult Checkout() {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            shopCart.ListShopItems = shopCart.getShopitems();

            if (shopCart.ListShopItems.Count == 0) {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            if (ModelState.IsValid) {
                allorder.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);

        }

        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.Data.Repozitory;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {

        private readonly IAllCar _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCar carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;


        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopitems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {

                ShopCart = _shopCart
            };

            return View(obj);



        }

        public RedirectToActionResult addToCart(int id) {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null) {
                _shopCart.AddToCart(item);
                        }

            return RedirectToAction("Index");
        
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Data.interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller { 

        private readonly IAllCar _carRep;
        
        public HomeController(IAllCar carRep) {
            _carRep = carRep;
            

        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars
            };
            return View(homeCars);
        }


    }
}

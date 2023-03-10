using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocrs
{
    public class MockCars : IAllCar {

        private readonly ICarsCategory _categoryCars = new MockCategory();
    
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car> {
                    new Car {
                        name = "Tesla" ,
                        shortDesc = "",
                        lognDesc = "",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First(),
                    },
                    new Car {
                        name = "Lada" ,
                        shortDesc = "",
                        lognDesc = "",
                        img = "/img/lada.webp",
                        price = 35000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First(),
                    },

                };
            }

        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getobjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}

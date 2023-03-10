using Microsoft.EntityFrameworkCore;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repozitory
{
    public class CarRepozitory : IAllCar {

        private readonly AppDBContent appDBContent;

        public CarRepozitory(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getobjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
             
        
    }
}

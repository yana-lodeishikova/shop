using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface IAllCar { 
    
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get;  }
        Car getobjectCar(int carId);
    }
}

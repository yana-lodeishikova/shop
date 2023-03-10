using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocrs
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {

                    new Category {categoryName = "Электромобили" , desc = "Севременный вид транспорта" },
                    new Category {categoryName = "Класические автомобили" , desc = "Машины с двигателем внутренного згорания" }
                };

            }
        }
    }
}


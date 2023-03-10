using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects {
        public static void Initial(AppDBContent content) {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Car.Any()) {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "",
                        lognDesc = "",
                        img = "",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Lada",
                        shortDesc = "",
                        lognDesc = "",
                        img = "",
                        price = 35000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Класические автомобили"]
                    }

                    );
            }

            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if (category == null)
                {

                    var list = new Category[] {
                         new Category {categoryName = "Электромобили" , desc = "Севременный вид транспорта" },
                         new Category {categoryName = "Класические автомобили" , desc = "Машины с двигателем внутренного згорания" }

                    };  
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                 
                }
                return category;
            }

        }
    }
}

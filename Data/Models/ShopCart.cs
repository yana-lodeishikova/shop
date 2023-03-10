using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {


        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartID { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", shopCartID);

            return new ShopCart(context) { ShopCartID = shopCartID };

        }

        public void AddToCart(Car car)
        {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartID = ShopCartID,
                Car = car,
                price = car.price

            });

            appDBContent.SaveChanges();

        }

        public List<ShopCartItem> getShopitems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartID == ShopCartID).Include(s => s.Car).ToList();
        }
    }
}

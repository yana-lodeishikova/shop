using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repozitory
{
    public class OrdersRepository : IAllOrder 
    {

        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart) {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        } 

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var el in items) {
                var orderDetail = new OrderDetail()
                {
                    carID = el.Car.id,
                    //orderID = order.id,
                    order = order,
                    price = el.Car.price
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}

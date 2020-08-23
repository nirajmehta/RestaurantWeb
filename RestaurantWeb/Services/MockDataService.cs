using RestaurantWeb.Interfaces;
using RestaurantWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWeb.Services
{
    public class MockDataService : IDataService
    {
        private static List<FoodItem> MenuList
        {
            get 
            {
                var menuList = new List<FoodItem>()
                {
                    new FoodItem() { Id = 1, Name = "Item1", Description = "Item1 Description", Price = 5},
                    new FoodItem() { Id = 2, Name = "Item2", Description = "Item2 Description", Price = 10},
                    new FoodItem() { Id = 3, Name = "Item3", Description = "Item3 Description", Price = 15}
                };

                return menuList;
            }
        }
        
        public List<FoodItem> GetMenuList()
        {
            return MenuList;
        }

        public bool PlaceOrder(IList<FoodItem> items, int id, out decimal grandTotal)
        {
            var orderDetails = new List<OrderDetail>();
            
            Order o = new Order();
            o.CustomerId = id;
            o.OrderDate = DateTime.Now;

            int orderId = 1;
            grandTotal = 0;
            foreach (var f in items)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = orderId,
                    FoodItemId = f.Id,
                    Quantity = f.Quantity,
                    TotalPrice = f.Price * f.Quantity,
                };
                orderDetails.Add(orderDetail);
                grandTotal += orderDetail.TotalPrice;

                o.TotalPaid = grandTotal;
                o.Status = 1;
                o.OrderDate = DateTime.Now;                
            }

            return true;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantWeb.Interfaces;
using RestaurantWeb.Models;

namespace RestaurantWeb.Services
{
    public class DataService : IDataService
    {
        private AppDbContext _appDbContext;
        
        public DataService()
        {
            _appDbContext = new AppDbContext();
        }

        public List<FoodItem> GetMenuList()
        {
            var menuItems = new List<FoodItem>();

            foreach (var fi in _appDbContext.FoodItems)
            {
                menuItems.Add(fi);
            }

            return menuItems;
        }

        public bool PlaceOrder(IList<FoodItem> items, int id, out decimal grandTotal)
        {
            bool dbSuccess = false;
            grandTotal = 0;
            try
            {
                Order o = new Order();
                o.CustomerId = id;
                o.OrderDate = DateTime.Now;

                _appDbContext.Orders.Add(o);
                _appDbContext.SaveChanges();

                int orderId = o.Id;
                //decimal grandTotal = 0;
                foreach (var f in items)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = orderId,
                        FoodItemId = f.Id,
                        Quantity = f.Quantity,
                        TotalPrice = f.Price * f.Quantity,
                    };
                    _appDbContext.OrderDetails.Add(orderDetail);
                    grandTotal += orderDetail.TotalPrice;
                }

                o.TotalPaid = grandTotal;
                o.Status = 1;
                o.OrderDate = DateTime.Now;
                _appDbContext.SaveChanges();
                dbSuccess = true;
            }
            catch (Exception ex)
            {
                //log exception
                dbSuccess = false;
            }            

            return dbSuccess;
        }
    }
}
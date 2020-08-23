using RestaurantWeb.Interfaces;
using RestaurantWeb.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace RestaurantWeb.Services
{
    public class MockMenuAdminService : IMenuAdminService
    {
        private List<FoodItem> MenuList { get; } = new List<FoodItem>()
        {
            new FoodItem() { Id = 1, Name = "Item1", Description = "Item1 Description", Price = 5},
            new FoodItem() { Id = 2, Name = "Item2", Description = "Item2 Description", Price = 10},
            new FoodItem() { Id = 3, Name = "Item3", Description = "Item3 Description", Price = 15}
        };

        public bool AddMenuItem(FoodItem item)
        {
            MenuList.Add(item);
            return true;
        }

        public bool DeleteMenuItem(int id)
        {
            var item = MenuList.Find(i => i.Id == id);
            MenuList.Remove(item);
            return true;
        }

        public IEnumerable<FoodItem> GetAllMenuItems()
        {
            return MenuList;
        }

        public FoodItem GetMenuItem(int id)
        {
            return MenuList.Find(i => i.Id == id);
        }

        public bool UpdateMenuItem(FoodItem item)
        {
            var itemToUpdate = MenuList.Find(i => i.Id == item.Id);
            itemToUpdate.Name = item.Name;
            itemToUpdate.Description = item.Description;
            itemToUpdate.Price = item.Price;
            return true;
        }
    }
}
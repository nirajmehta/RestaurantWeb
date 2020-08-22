using RestaurantWeb.Models;
using RestaurantWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestaurantWeb.Services
{
    public class MenuAdminService : IMenuAdminService
    {
        private AppDbContext _appDbContext;

        public MenuAdminService()
        {
            _appDbContext = new AppDbContext();
        }

        public IEnumerable<FoodItem> GetAllMenuItems()
        {
            try
            {
                return _appDbContext.FoodItems.ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool AddMenuItem(FoodItem item)
        {
            try
            {
                _appDbContext.FoodItems.Add(item);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateMenuItem(FoodItem item)
        {
            try
            {
                _appDbContext.Entry(item).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public FoodItem GetMenuItem(int id)
        {
            try
            {
                FoodItem item = _appDbContext.FoodItems.Find(id);
                return item;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteMenuItem(int id)
        {
            try
            {
                FoodItem item = _appDbContext.FoodItems.Find(id);
                _appDbContext.FoodItems.Remove(item);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }        
    }
}
using RestaurantWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWeb.Interfaces
{
    public interface IMenuAdminService
    {
        IEnumerable<FoodItem> GetAllMenuItems();
        bool AddMenuItem(FoodItem item);
        bool UpdateMenuItem(FoodItem item);
        FoodItem GetMenuItem(int id);
        bool DeleteMenuItem(int id);

    }
}

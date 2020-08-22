using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantWeb.Models;

namespace RestaurantWeb.Interfaces
{
    public interface IDataService
    {
        List<FoodItem> GetMenuList();

        bool PlaceOrder(IList<FoodItem> items, int id);


    }
}

using RestaurantWeb.Interfaces;
using RestaurantWeb.Models;
using RestaurantWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWeb.Controllers
{
    public class DataController : Controller
    {
        private IDataService _dataService;
        public IList<FoodItem> menuItems;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }


        // GET: Data

        [HttpGet] 
        public ActionResult GetMenuList()
        {
            menuItems = _dataService.GetMenuList();

            return Json(menuItems, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [AuthorizeUser]        
        public string GetUserId()
        {
            int uid = -1;
            if (Session["UserId"] != null)
                uid = Convert.ToInt32(Session["UserId"].ToString());
            return uid.ToString();
        }

        [HttpPost]
        [AuthorizeUser]
        public ActionResult PlaceOrder(IList<FoodItem> items, int id)
        {
            decimal grandTotal = 0;
            bool dbSuccess = _dataService.PlaceOrder(items, id, out grandTotal);

            if (dbSuccess)
                return Json("success: true", JsonRequestBehavior.AllowGet);
            else
                return Json("success: false", JsonRequestBehavior.AllowGet);

        }
    }

}
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
    //change to [AuthorizeAdmin] to only allow Admin access
    [AuthorizeUser] 
    public class MenuAdminController : Controller
    {
        private IMenuAdminService _menuAdminService;
        public IList<FoodItem> menuItems;

        public MenuAdminController(IMenuAdminService menuAdminService)
        {
            _menuAdminService = menuAdminService;
        }

        // GET: MenuAdmin
        [HttpGet]
        public ActionResult Index()
        {
            menuItems = _menuAdminService.GetAllMenuItems().ToList();

            return View(menuItems);
        }

        // GET: MenuAdmin/Details/5
        public ActionResult Details(int id)
        {
            var menuItem = _menuAdminService.GetMenuItem(id);
            return Json(menuItem, JsonRequestBehavior.AllowGet);
        }

        // GET: MenuAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuAdmin/Create
        [HttpPost]
        public ActionResult Create(FoodItem item)
        {
            bool dbSuccess = false;

            if (ModelState.IsValid)
            {
                item.Picture = "Image_Awaited.png"; //default image
                dbSuccess = _menuAdminService.AddMenuItem(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MenuAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            var menuItem = _menuAdminService.GetMenuItem(id);

            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FoodItem newItem)
        {
            if (ModelState.IsValid)
            {
                var item = _menuAdminService.GetMenuItem(id);
                if (item == null)
                {
                    return HttpNotFound();
                }

                item.Name = newItem.Name;
                item.Description = newItem.Description;
                item.Price = newItem.Price;

                bool dbSuccess = _menuAdminService.UpdateMenuItem(item);
                return RedirectToAction("Index");
            }
            return View(newItem);
        }

        // GET: MenuAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var item = _menuAdminService.GetMenuItem(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: MenuAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FoodItem item)
        {
            bool dbSuccess = _menuAdminService.DeleteMenuItem(id);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantWeb.Interfaces;
using RestaurantWeb.Models;
using RestaurantWeb.Services;
using Unity;
using Unity.Mvc5;

namespace RestaurantTests
{
    [TestClass]
    public class MenuAdminServiceTest
    {
        public static UnityContainer container;
        private IMenuAdminService menuAdminService;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            container = new UnityContainer();
            container.RegisterType<IMenuAdminService, MockMenuAdminService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            menuAdminService = container.Resolve<IMenuAdminService>();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            container = null;
        }

        [TestMethod]
        public void MenuAdminServiceIsNotNull()
        {
            Assert.IsTrue(menuAdminService is MockMenuAdminService);
        }

        [TestMethod]
        public void MenuListHasFoodItems()
        {
            var menuList = menuAdminService.GetAllMenuItems();
            Assert.AreEqual(3, menuList.ToList().Count);
        }

        [TestMethod]
        public void GetSpecificItemFromMenuList()
        {
            var item = menuAdminService.GetMenuItem(1);
            Assert.AreEqual("Item1", item.Name);
        }

        [TestMethod]
        public void AddItemToMenuList()
        {
            menuAdminService.AddMenuItem(new FoodItem() { Id = 4, Name = "Item4", Description = "Item4 Description", Price = 20 });
            var menuList = menuAdminService.GetAllMenuItems();
            Assert.AreEqual(4, menuList.ToList().Count);
        }

        [TestMethod]
        public void UpdateItemInMenuList()
        {
            menuAdminService.UpdateMenuItem(new FoodItem() { Id = 1, Name = "Item1 updated", Description = "Item1 Description", Price = 10 });
            var item = menuAdminService.GetMenuItem(1);
            Assert.AreEqual("Item1 updated", item.Name);
        }

        [TestMethod]
        public void DeleteItemFromMenuList()
        {
            menuAdminService.DeleteMenuItem(1);
            var item = menuAdminService.GetMenuItem(1);
            Assert.IsNull(item);
        }


    }
}

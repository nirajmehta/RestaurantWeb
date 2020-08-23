using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Mvc5;
using Unity.Injection;
using RestaurantWeb.Interfaces;
using RestaurantWeb.Services;
using System.Web.Mvc;
using System.Linq;
using RestaurantWeb.Models;

namespace RestaurantTests
{
    [TestClass]
    public class DataServiceTest
    {
        public static UnityContainer container;
        private IDataService dataService;
        
        [TestInitialize()]
        public void MyTestInitialize()
        {
            container = new UnityContainer();
            container.RegisterType<IDataService, MockDataService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            dataService = container.Resolve<IDataService>();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            container = null;
        }

        [TestMethod]
        public void DataServiceIsNotNull()
        {
            Assert.IsTrue(dataService is MockDataService);
        }

        [TestMethod]
        public void MenuListHasFoodItems()
        {
            var menuList = dataService.GetMenuList();
            Assert.AreEqual(3, menuList.Count);
        }

        [TestMethod]
        public void GetSpecificItemFromMenuList()
        {
            var menuList = dataService.GetMenuList();
            Assert.IsNotNull(menuList.FirstOrDefault());
            Assert.AreEqual("Item1", menuList.FirstOrDefault().Name);
        }

        [TestMethod]
        public void PlaceOrderReturnsGrandTotal()
        {
            var menuList = dataService.GetMenuList();

            var orderedItems = new List<FoodItem>();
            foreach (var item in menuList)
            {
                orderedItems.Add(new FoodItem()
                {
                    Id = item.Id,
                    Quantity = 2,
                    Price = item.Price
                });
            }

            decimal grandTotal = 0;
            dataService.PlaceOrder(orderedItems, id: 1, out grandTotal);

            Assert.AreEqual(60, grandTotal);
        }
    }
}

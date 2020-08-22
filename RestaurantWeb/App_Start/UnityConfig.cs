using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using RestaurantWeb.Interfaces;
using RestaurantWeb.Services;
using RestaurantWeb.Controllers;
using Unity.Injection;

namespace RestaurantWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here  
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<DataController>(new InjectionConstructor(typeof(IDataService)));
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<HomeController>(new InjectionConstructor());
            container.RegisterType<MenuAdminController>(new InjectionConstructor(typeof(IMenuAdminService)));
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<IMenuAdminService, MenuAdminService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
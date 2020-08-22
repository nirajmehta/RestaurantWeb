using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RestaurantWeb.Models;
using System.Linq;
using System.Web.Security;

[assembly: OwinStartupAttribute(typeof(RestaurantWeb.Startup))]
namespace RestaurantWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //create admin user 
            var dbContext = new AppDbContext();
            //if admin user doesn't exist, create one
            Customer adminUser = dbContext.Customers.Where(u => u.Email == "admin@nirajseatery.com").FirstOrDefault();
            if (adminUser == null) 
            {
                adminUser = new Customer();
                adminUser.Email = "admin@nirajseatery.com";
                adminUser.Password = "password";
                adminUser.Role = Roles.Admin.ToString();

                dbContext.Customers.Add(adminUser);
                dbContext.SaveChanges();
            }
        }
    }

    public enum Roles
    {
        Admin,
        Customer
    }
}

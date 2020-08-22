using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWeb.Utilities
{
    public class AuthorizeAdmin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");

            if (httpContext.Session["Email"] == null)
            {
                return false;
            }

            if ((string)httpContext.Session["Email"] != "admin@nirajseatery.com")
            {
                return false;
            }

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (this.AuthorizeCore(filterContext.HttpContext) == false)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWeb.Utilities
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");

            // Make sure the user logged in.
            if (httpContext.Session["Email"] == null)
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
                filterContext.Result = new RedirectResult("/Account/Login/?ret=" + filterContext.HttpContext.Request.CurrentExecutionFilePath);
            }
        }
    }
}
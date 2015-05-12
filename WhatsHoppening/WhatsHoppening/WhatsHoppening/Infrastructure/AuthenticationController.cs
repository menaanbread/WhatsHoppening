using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WhatsHoppening.Domain;

namespace WhatsHoppening.Infrastructure
{
    public class AuthenticationController : Controller
    {
        private HopCore core = null;

        public AuthenticationController(HopCore core)
        {
            this.core = core;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!core.IsUserAuthenticated(CurrentUser))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Login"
                }));
            }
        }

        public HopCore Core { get { return core; } internal set { core = value; } }

        public User CurrentUser 
        {
            get { return Core.GetCurrentUser(); } 
        }
    }
}
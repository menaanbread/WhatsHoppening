using System.Web.Mvc;
using System.Web.Routing;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Infrastructure
{
    public class AuthenticatedController : Controller
    {
        private HopService _hopService = null;

        public AuthenticatedController(HopService hopService)
        {
            this._hopService = hopService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!_hopService.IsAuthenticatedSession())
            {
                ViewBag.LoggedIn = false;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Login"
                }));
            }

            ViewBag.LoggedIn = true;
        }

        public HopService HopService { get { return _hopService; } internal set { _hopService = value; } }

        public ILogger Log { get { return _hopService.Logger; } }

        public User CurrentUser 
        {
            get { return HopService.GetCurrentUser(); } 
        }
    }
}
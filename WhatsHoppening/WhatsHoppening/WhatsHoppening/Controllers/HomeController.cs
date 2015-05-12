using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Infrastructure;

namespace WhatsHoppening.Controllers
{
    public class HomeController : AuthenticationController
    {
        public HomeController(HopCore core) : base(core) { }

        public ActionResult Index()
        {
            return View(Core.ListAllPosts());
        }
    }
}
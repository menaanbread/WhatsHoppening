using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Infrastructure;

namespace WhatsHoppening.Controllers
{
    public class HomeController : AuthenticatedController
    {
        public HomeController(HopService core) : base(core) { }

        public ActionResult Index()
        {
            return View(HopService.ListAllPosts());
        }
    }
}
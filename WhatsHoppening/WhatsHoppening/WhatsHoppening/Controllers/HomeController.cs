using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Infrastructure;

namespace WhatsHoppening.Controllers
{
    public class HomeController : Controller
    {
        private HopCore core = null;

        public HomeController(HopCore core)
        {
            this.core = core;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(core.ListAllPosts());
        }
    }
}
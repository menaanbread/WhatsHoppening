using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_v0._1.Controllers
{
    public class AuthdController : Controller
    {
        public ActionResult Index()
        {
            // do some check authentication stuff
            return View();
        }

    }
}

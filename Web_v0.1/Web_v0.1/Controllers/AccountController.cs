using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_v0._1.Models;

namespace Web_v0._1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index(string un)
        {
            string username = string.IsNullOrEmpty(un) ? "" : un;
            AccountRepository ar = new AccountRepository();
            AccountModel am = ar.Get(username);
            return View(am);
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            AccountRepository ar = new AccountRepository();
            bool authenticated = ar.Authenticate(lvm.Username, lvm.Password);

            //cleanse returnUrl 
            string rUrl = lvm.ReturnUrl.Replace("/", "");
            
            if (authenticated)
            {
                return RedirectToAction("Index", (rUrl.Equals("") ? "Home" : rUrl));
            }
            else 
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Infrastructure;
using WhatsHoppening.Models;

namespace WhatsHoppening.Controllers
{
    public class LoginController : Controller
    {
        private HopCore core = null;

        public LoginController(HopCore core)
        {
            this.core = core;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            core.AuthenticateUser(loginViewModel.Username, loginViewModel.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Infrastructure;
using WhatsHoppening.Models;
using WhatsHoppening.Extensions;

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
            try
            {
                core.AuthenticateUser(loginViewModel.Username, loginViewModel.Password);
            }
            catch (ApplicationException e)
            {
                core.Logger.Log(Domain.LogSeverity.Warn, "User {0} entered invalid password.".FormatWith(loginViewModel.Username));
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                core.Logger.Log(Domain.LogSeverity.Warn, "User attempted to log in with name that does not exist : {0}".FormatWith(loginViewModel.Username));
                return RedirectToAction("Login");
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                core.RevokeAuthentication();
                return RedirectToAction("Login", "Login");
            }
            catch (Exception e)
            {
                core.Logger.Log(Domain.LogSeverity.Error, "Error occured in Logout", e);
                throw e;
            }
        }
    }
}
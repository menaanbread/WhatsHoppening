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
    public class LoginController : UnauthenticatedController
    {
        public LoginController(HopCore core) : base(core) { }

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
                Core.AuthenticateUser(loginViewModel.Username, loginViewModel.Password);
            }
            catch (ApplicationException e)
            {
                Log.Log(Domain.LogSeverity.Warn, "User {0} entered invalid password.".FormatWith(loginViewModel.Username));
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                Log.Log(Domain.LogSeverity.Warn, "User attempted to log in with name that does not exist : {0}".FormatWith(loginViewModel.Username));
                return RedirectToAction("Login");
            }

            ViewBag.LoggedIn = true;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                Core.RevokeAuthentication();

                ViewBag.LoggedIn = false;

                return RedirectToAction("Login", "Login");
            }
            catch (Exception e)
            {
                Log.Log(Domain.LogSeverity.Error, "Error occured in Logout", e);
                throw e;
            }
        }
    }
}
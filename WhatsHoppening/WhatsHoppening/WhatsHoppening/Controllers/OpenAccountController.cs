using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Domain;
using WhatsHoppening.Infrastructure;
using WhatsHoppening.Models;
using WhatsHoppening.Extensions;

namespace WhatsHoppening.Controllers
{
    public class OpenAccountController : UnauthenticatedController
    {
        public OpenAccountController(HopService core) : base(core) { }

        [HttpGet]
        public ActionResult JoinNow()
        {
            var defaultDetails = new OpenAccountViewModel()
            {
                Country = Domain.Country.UnitedKingdom
            };

            return View(defaultDetails);
        }

        [HttpPost]
        public ActionResult JoinNow(OpenAccountViewModel accountDetails)
        {
            if (ModelState.IsValid)
            {
                var newUserId = HopService.OpenAccount(accountDetails.Username, accountDetails.Password, accountDetails.Location, accountDetails.Country);

                if (newUserId > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Log.Log(LogSeverity.Error, "Open account failed with username {0}".FormatWith(accountDetails.Username));
                    return View(accountDetails);
                }
            }
            else
            {
                return View(accountDetails);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_v0._1.Models;

namespace Web_v0._1.Controllers
{
    public class OpenAccountController : Controller
    {
        //
        // GET: /OpenAccount/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /OpenAccount/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OpenAccount/Create
        [HttpPost]
        public ActionResult Create(AccountModel account)
        {
            try
            {
                AccountRepository ar = new AccountRepository();
                if (ar.Add(account))
                {
                    return RedirectToAction("Index", "Home", new { un = account.Username });
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
                
    }
}

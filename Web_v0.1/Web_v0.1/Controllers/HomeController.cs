using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_v0._1.Models;

namespace Web_v0._1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(string un)
        {
            string username = string.IsNullOrEmpty(un) ? "" : un;
            AccountRepository ar = new AccountRepository();
            PostRepository pr = new PostRepository();
            
            AccountModel am = ar.Get(username);
            List<PostModel> posts = pr.FrontPagePosts();

            HomeViewModel hvm = new HomeViewModel()
            {
                Account = am,
                Posts = posts
            };

            return View(hvm);
        }

    }
}

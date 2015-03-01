using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_v0._1.Models;

namespace Web_v0._1.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            IBreweryRepository brewR = new BreweryRepository();
            IBeerRepository beerR = new BeerRepository();
            IBarRepository barR = new BarRepository();
            
            PostViewModel pvm = new PostViewModel()
            {
                Breweries = brewR.GetBreweries(),
                Beers = beerR.GetBeers(),
                Bars = barR.GetBars()
            };

            pvm.BreweryNames = pvm.Breweries.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            pvm.BeerNames = pvm.Beers.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            pvm.BarNames = pvm.Bars.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });

            return View(pvm);
        }

        [HttpPost]
        public ActionResult Index(PostViewModel pvm)
        {
            try
            {
                IPostRepository pr = new PostRepository();
                if (pr.AddPost(pvm))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(pvm);
                }
            }
            catch
            {
                return View(pvm);
            }
        }

        public ActionResult AddBrewery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBrewery(BreweryModel brewery)
        {
            try
            {
                IBreweryRepository br = new BreweryRepository();
                if (br.Add(brewery))
                {
                    return RedirectToAction("Index", "Post");
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

        public ActionResult AddBeer()
        {
            IBreweryRepository brewR = new BreweryRepository();
            AddBeerViewModel bvm = new AddBeerViewModel()
            {
                Breweries = brewR.GetBreweries()
            };
            bvm.BreweryNames = bvm.Breweries.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            return View(bvm);
        }

        [HttpPost]
        public ActionResult AddBeer(BeerModel beer)
        {
            try
            {
                IBeerRepository br = new BeerRepository();
                if (br.AddBeer(beer))
                {
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    return AddBeer();
                }
            }
            catch
            {
                return AddBeer();
            }
        }

        public ActionResult AddBar()
        {
            return View(new AddBarViewModel());
        }

        [HttpPost]
        public ActionResult AddBar(BarModel bar)
        {
            try
            {
                IBarRepository br = new BarRepository();
                if (br.AddBar(bar))
                {
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    return View(new AddBarViewModel());
                }
            }
            catch
            {
                return View(new AddBarViewModel());
            }
        }

    }
}

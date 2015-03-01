using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_v0._1.Models
{
    public class PostViewModel
    {

        [Display(Name = "Brewery")]
        public int SelectedBrewery { get; set; }
        public IEnumerable<BreweryModel> Breweries { get; set; }
        public IEnumerable<SelectListItem> BreweryNames { get; set; }

        [Display(Name = "Beer")]
        public int SelectedBeer { get; set; }
        public IEnumerable<BeerModel> Beers { get; set; }
        public IEnumerable<SelectListItem> BeerNames { get; set; }

        [Display(Name = "Bar")]
        public int SelectedBar { get; set; }
        public IEnumerable<BarModel> Bars { get; set; }
        public IEnumerable<SelectListItem> BarNames { get; set; }

        public byte Rating { get; set; }

        public string Description { get; set; }

    }
}
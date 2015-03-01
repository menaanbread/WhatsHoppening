using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_v0._1.Models
{
    public class AddBeerViewModel
    {
        public BeerModel Beer { get; set; }

        [Display(Name = "Brewery")]
        public int SelectedBrewery { get; set; }
        public IEnumerable<BreweryModel> Breweries { get; set; }
        public IEnumerable<SelectListItem> BreweryNames { get; set; }
    }
}
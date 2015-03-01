using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_v0._1.Models
{
    public class AddBarViewModel
    {
        [Display(Name = "BarType")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a valid type")]
        public BarModel.BarType Type { get; set; }

        public BarModel Bar { get; set; }
    }
}
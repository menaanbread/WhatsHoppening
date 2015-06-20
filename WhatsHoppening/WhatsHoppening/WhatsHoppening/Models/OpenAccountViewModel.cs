using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsHoppening.Domain;

namespace WhatsHoppening.Models
{
    public class OpenAccountViewModel
    {
        public string Username { get; set; }
        public Country Country { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
    }
}
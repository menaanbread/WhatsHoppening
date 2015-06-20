using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class Registration
    {
        public string Username { get; set; }
        public Country Country { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
    }
}

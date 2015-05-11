using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class HomeVenue : IVenue
    {
        private BarStyle barStyle;

        public HomeVenue()
        {
            barStyle = BarStyle.Home;
        }

        public HomeVenue(BarStyle barStyle)
        {
            this.barStyle = barStyle;
        }

        public string Name 
        {
            get { return barStyle.ToString("g"); }
            set { throw new ApplicationException("Cannot change name of home."); } 
        }
        
        public string Location 
        { 
            get { return "Where the heart is"; }
            set { throw new ApplicationException("Cannot change home location."); } 
        }

        public BarStyle BarStyle
        {
            get { return barStyle; }
        }

        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Device.Location;
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
        
        public GeoCoordinate Location 
        { 
            get { return GeoCoordinate.Unknown; }
            set { throw new ApplicationException("Cannot change home location."); } 
        }

        public BarStyle BarStyle
        {
            get { return barStyle; }
        }

        public int Id { get; set; }
    }
}

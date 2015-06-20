using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace WhatsHoppening.Domain
{
    public class Bar : IVenue
    {
        private BarStyle barStyle;

        public Bar()
        {
            barStyle = BarStyle.Bar;
        }

        public Bar(BarStyle barStyle)
        {
            this.barStyle = barStyle;
        }

        public Bar(string website, string name, GeoCoordinate location, BarStyle barStyle, Country country)
        {
            Website = website;
            Name = name;
            Location = location;
            this.barStyle = barStyle;
            Country = country;
        }

        public string Website { get; set; }
        public string Name { get; set; }
        public GeoCoordinate Location { get; set; }
        public BarStyle BarStyle { get { return barStyle; } }
        public Country Country { get; set; }
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Bar(string website, string name, string location, BarStyle barStyle)
        {
            Website = website;
            Name = name;
            Location = location;
            this.barStyle = barStyle;
        }

        public string Website { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public BarStyle BarStyle { get { return barStyle; } }
        public int Id { get; set; }
    }
}

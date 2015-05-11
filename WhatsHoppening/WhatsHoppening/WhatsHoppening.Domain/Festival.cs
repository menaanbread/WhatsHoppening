using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class Festival : IVenue
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Id { get; set; }
        public BarStyle BarStyle
        {
            get { return Domain.BarStyle.Festival; }
        }
    }
}

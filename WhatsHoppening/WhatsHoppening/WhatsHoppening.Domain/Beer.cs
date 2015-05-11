using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BeerStyle Style { get; set; }
        public double Abv { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
    }
}

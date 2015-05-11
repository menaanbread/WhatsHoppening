using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class SearchPostQuery
    {
        public string Content { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public User User { get; set; }
        public Beer Beer { get; set; }
        public IVenue Bar{ get; set; }
        public double MinRating { get; set; }
    }
}

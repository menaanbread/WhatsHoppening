using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Beer Beer { get; set; }
        public IVenue Bar { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Rating { get; set; }
    }
}

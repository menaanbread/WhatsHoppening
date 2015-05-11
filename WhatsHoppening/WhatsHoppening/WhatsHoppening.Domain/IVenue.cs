using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain
{
    public interface IVenue
    {
        int Id { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        BarStyle BarStyle { get; }
    }
}

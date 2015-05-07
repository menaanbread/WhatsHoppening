using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ILocationManager
    {
        /* NOTE THESE ARE OBJECTS, NEED TO UPDATE TO SOMETHING MORE SUITABLE! */
        object GetCurrentLoction();
        object LookupLocation(object coordinates);
    }
}

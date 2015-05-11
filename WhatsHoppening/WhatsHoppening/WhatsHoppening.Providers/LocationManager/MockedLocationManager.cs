using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.LocationManager
{
    public class MockedLocationManager : ILocationManager
    {
        public object GetCurrentLoction()
        {
            throw new NotImplementedException();
        }

        public object LookupLocation(object coordinates)
        {
            throw new NotImplementedException();
        }
    }
}

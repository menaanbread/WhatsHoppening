using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.ClientStorage
{
    public class WriteClientStorageRequest
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Session
{
    public class SessionAuthenticationRequest
    {
        public string SessionId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

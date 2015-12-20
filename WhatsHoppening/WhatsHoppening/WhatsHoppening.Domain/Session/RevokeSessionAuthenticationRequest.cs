using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Session
{
    public class RevokeSessionAuthenticationRequest
    {
        public static implicit operator RevokeSessionAuthenticationRequest(string authenticatedSessionId)
        {
            return new RevokeSessionAuthenticationRequest() { AuthenticatedSessionId = authenticatedSessionId };
        }

        public string AuthenticatedSessionId { get; set; }
    }
}

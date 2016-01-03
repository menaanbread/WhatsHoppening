using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Session.SessionInformation
{
    public class SessionInformationResponse
    {
        public SessionInformationResponse()
        {
            RequestedSessionInformation = new Dictionary<SessionInformationType, string>();
        }

        public Dictionary<SessionInformationType, string> RequestedSessionInformation;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Session.SessionInformation
{
    public class SessionInformationRequest
    {
        public string SessionId { get; set; }
        public List<SessionInformationType> RequestedSessionInformation;
    }
}

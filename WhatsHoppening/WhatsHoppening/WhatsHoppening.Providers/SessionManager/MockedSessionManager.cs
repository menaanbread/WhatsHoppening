using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.SessionManager
{
    public class MockedSessionManager : ISessionManager
    {
        public void AuthenticateUser(Domain.AuthenticationRequest authenticationRequest)
        {
            throw new NotImplementedException();
        }

        public void RevokeAuthentication(Domain.User user)
        {
            throw new NotImplementedException();
        }

        public bool HasAuthentication(Domain.User user)
        {
            throw new NotImplementedException();
        }
    }
}

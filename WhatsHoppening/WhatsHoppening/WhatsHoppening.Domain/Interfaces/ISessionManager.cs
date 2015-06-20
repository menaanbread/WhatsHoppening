using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ISessionManager
    {
        void AuthenticateUser(AuthenticationRequest authenticationRequest);
        void RevokeAuthentication(User user);
        bool HasAuthentication(User user);
        void CreateAuthenticatedSession(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain;
using WhatsHoppening.Providers.UserManager;
using WhatsHoppening.Extensions;

namespace WhatsHoppening.Providers.SessionManager
{
    public class MockedSessionManager : ISessionManager
    {
        private static Dictionary<string, string> users = null;
        private static List<User> authorisedUsers = null;
        private static IUserManager userManager;

        public MockedSessionManager()
        {
            authorisedUsers = new List<User>();
            users = new Dictionary<string, string>();
            
            userManager = new MockedUserManager();
            
            users.Add("Tom", "memtest");
            users.Add("t", "");
        }

        public void AuthenticateUser(AuthenticationRequest authenticationRequest)
        {
            if (users[authenticationRequest.Username].Equals(authenticationRequest.Password, StringComparison.InvariantCultureIgnoreCase))
            {
                authorisedUsers.Add(userManager.GetUser(authenticationRequest.Username));
            }
            else
            {
                throw new ApplicationException("User {0} not authorised / does not exist.".FormatWith(authenticationRequest.Username));
            }
        }

        public void RevokeAuthentication(User user)
        {
            authorisedUsers.Remove(user);
        }

        public bool HasAuthentication(User user)
        {
            return authorisedUsers.Exists(u => u == user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain;
using WhatsHoppening.Providers.UserManager;
using WhatsHoppening.Extensions;
using System.Web;

namespace WhatsHoppening.Providers.SessionManager
{
    public class MockedSessionManager : ISessionManager
    {
        private static Dictionary<string, string> users = null;
        private static List<User> authorisedUsers = new List<User>();
        private static IUserManager userManager;

        private const string USER_COOKIE = "user_id";

        static MockedSessionManager()
        {
            users = new Dictionary<string, string>();
            
            userManager = new MockedUserManager();
            
            users.Add("tom", "memtest");
            users.Add("t", "");
        }

        public void AuthenticateUser(AuthenticationRequest authenticationRequest)
        {
            if (users[authenticationRequest.Username].Equals(authenticationRequest.Password, StringComparison.InvariantCultureIgnoreCase))
            {
                CreateAuthenticatedSession(userManager.GetUser(authenticationRequest.Username));
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
            return authorisedUsers.Exists(u => u.Id == user.Id);
        }

        /// <summary>
        /// Directly creates a session for a user without checking authorisation.
        /// Don't use outside this class unless there is a reason (e.g. just openend an account).
        /// </summary>
        public void CreateAuthenticatedSession(User user)
        {
            var cookies = HttpContext.Current.Response.Cookies;

            cookies.Add(new HttpCookie(USER_COOKIE, user.Id.ToString()));

            authorisedUsers.Add(user);
        }
    }
}

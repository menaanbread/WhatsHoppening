using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Infrastructure
{
    public class HopCore
    {
        private ILocationManager locationManager = null;
        private ILogger logger = null;
        private IPermissionsManager permissionsManager = null;
        private IPersistenceProvider persistenceProvider = null;
        private ISessionManager sessionManager = null;
        private IUserManager userManager = null;

        public HopCore(ILocationManager locationManager, ILogger logger, IPermissionsManager permissionsManager, IPersistenceProvider persistenceProvider, ISessionManager sessionManager, IUserManager userManager)
        {
            this.locationManager = locationManager;
            this.logger = logger;
            this.permissionsManager = permissionsManager;
            this.persistenceProvider = persistenceProvider;
            this.sessionManager = sessionManager;
            this.userManager = userManager;
        }

        public List<Post> ListAllPosts()
        {
            var posts = new List<Post>();

            try
            {
                posts = persistenceProvider.ListPosts();
            }
            catch (Exception e)
            {
                logger.Log(LogSeverity.Error, "Error trying to perform ListAllPosts operation", e);
                throw e;
            }

            return posts;
        }

        public User GetCurrentUser()
        {
            User user = null;

            try
            {
                user = userManager.GetUser();
            }
            catch (Exception e)
            {
                logger.Log(LogSeverity.Error, "Error trying to perform GetCurrentUser operation", e);
                throw e;
            }

            return user;
        }

        public bool IsUserAuthenticated(User user)
        {
            bool authenticated = false;

            try
            {
                authenticated = sessionManager.HasAuthentication(user);
            }
            catch (Exception e)
            {
                logger.Log(LogSeverity.Error, "Error trying to perform IsUserAuthenticated operation", e);
                throw e;
            }

            return authenticated;
        }

        public void AuthenticateUser(string username, string password)
        {
            try
            {
                sessionManager.AuthenticateUser(new AuthenticationRequest() { Username = username, Password = password }); 
            }
            catch (Exception e)
            {
                logger.Log(LogSeverity.Error, "Error trying to perform IsUserAuthenticated operation", e);
                throw e;
            }
        }
    }
}

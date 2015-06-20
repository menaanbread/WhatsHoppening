using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Extensions;

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

        public ILogger Logger 
        {
            get { return logger; } 
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

        public void RevokeAuthentication()
        {
            try
            {
                sessionManager.RevokeAuthentication(GetCurrentUser());
            }
            catch (Exception e)
            {
                logger.Log(LogSeverity.Error, "Error trying to perform RevokeAuthentication operation", e);
                throw e;
            }
        }

        public int OpenAccount(string username, string password, string location, Country country)
        {
            int newId = -1;

            try
            {
                var registration = new Registration()
                {
                    Username = username,
                    Password = password,
                    Location = location,
                    Country = country
                };

                if (!userManager.UsernameExists(username))
                {
                    var newUser = userManager.OpenAccount(registration);
                    newId = newUser.Id;
                    sessionManager.CreateAuthenticatedSession(newUser);
                }
            }
            catch(Exception e)
            {
                logger.Log(LogSeverity.Warn, "Error attemtping to oppen account with Username {0}".FormatWith(username), e);
            }

            return newId;
        }
    }
}

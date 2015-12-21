using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain.Session;
using WhatsHoppening.Domain.Session.SessionInformation;
using WhatsHoppening.Extensions;

namespace WhatsHoppening.Infrastructure
{
    public class HopService
    {
        private readonly ILocationManager _locationManager = null;
        private readonly ILogger _logger = null;
        private readonly IPermissionsManager _permissionsManager = null;
        private readonly IPersistenceProvider _persistenceProvider = null;
        private readonly ISessionManager _sessionManager = null;
        private readonly IUserManager _userManager = null;

        public HopService(ILocationManager locationManager, ILogger logger, IPermissionsManager permissionsManager, IPersistenceProvider persistenceProvider, ISessionManager sessionManager, IUserManager userManager)
        {
            _locationManager = locationManager;
            _logger = logger;
            _permissionsManager = permissionsManager;
            _persistenceProvider = persistenceProvider;
            _sessionManager = sessionManager;
            _userManager = userManager;
        }

        public ILogger Logger 
        {
            get { return _logger; } 
        }

        public List<Post> ListAllPosts()
        {
            var posts = new List<Post>();

            try
            {
                posts = _persistenceProvider.ListPosts();
            }
            catch (Exception e)
            {
                _logger.Log(LogSeverity.Error, "Error trying to perform ListAllPosts operation", e);
                throw e;
            }

            return posts;
        }

        public void CreateSession()
        {
            try
            {
                _sessionManager.CreateSession();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ac exception occurred trying to create a new session.", e);
            }
        }

        public User GetCurrentUser()
        {
            User user = null;

            try
            {
                var userId = int.Parse(_sessionManager.RetrieveSessionInformation(new SessionInformationRequest()
                {
                    SessionId = _sessionManager.SessionId,
                    RequestedSessionInformation = new List<SessionInformationType>() { SessionInformationType.UserId }
                }).RequestedSessionInformation.First().Value);

                user = _userManager.GetUser(userId);
            }
            catch (Exception e)
            {
                _logger.Log(LogSeverity.Error, "Error trying to perform GetCurrentUser operation", e);
                throw e;
            }

            return user;
        }

        public bool IsUserAuthenticated(User user)
        {
            bool authenticated = false;

            try
            {
                authenticated = _sessionManager.IsAuthenticatedSession;
            }
            catch (Exception e)
            {
                _logger.Log(LogSeverity.Error, "Error trying to perform IsUserAuthenticated operation", e);
                throw e;
            }

            return authenticated;
        }

        public void AuthenticateUser(string username, string password)
        {
            try
            {
                _sessionManager.AuthenticateSession(new SessionAuthenticationRequest()
                {
                    SessionId = _sessionManager.SessionId,
                    Username = username,
                    Password = password
                });
            }
            catch (Exception e)
            {
                _logger.Log(LogSeverity.Error, "Error trying to perform IsUserAuthenticated operation", e);
                throw e;
            }
        }

        public void RevokeAuthentication()
        {
            try
            {
                _sessionManager.RevokeSessionAuthentication(new RevokeSessionAuthenticationRequest()
                {
                    AuthenticatedSessionId = _sessionManager.SessionId
                });
            }
            catch (Exception e)
            {
                _logger.Log(LogSeverity.Error, "Error trying to perform RevokeAuthentication operation", e);
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

                if (!_userManager.UsernameExists(username))
                {
                    var newUser = _userManager.OpenAccount(registration);
                    newId = newUser.Id;
                    _sessionManager.AuthenticateSession(new SessionAuthenticationRequest()
                    {
                        SessionId = _sessionManager.SessionId,
                        Password = password,
                        Username = username
                    });
                }
            }
            catch(Exception e)
            {
                _logger.Log(LogSeverity.Warn, "Error attemtping to oppen account with Username {0}".FormatWith(username), e);
            }

            return newId;
        }

        public bool IsAuthenticatedSession()
        {
            var isAuthenticated = false;

            try
            {
                isAuthenticated = _sessionManager.IsAuthenticatedSession;
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred checking if the session was authenticated", e);
            }

            return isAuthenticated;
        }
    }
}

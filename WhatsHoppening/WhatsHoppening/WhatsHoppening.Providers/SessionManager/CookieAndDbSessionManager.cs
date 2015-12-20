using System;
using WhatsHoppening.Extensions;
using WhatsHoppening.Domain.ClientStorage;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain.Session;
using WhatsHoppening.Domain.Session.SessionInformation;
using WhatsHoppening.Domain.UserManager.Authentication;

namespace WhatsHoppening.Providers.SessionManager
{
    public class CookieAndDbSessionManager : ISessionManager
    {
        private const string SESSION_COOKIE_NAME = "session";

        private readonly IClientStorageProvider _clientStorageProvider = null;
        private readonly IUserManager _userManager = null;
        private readonly ILogger _logger = null;
        private ISessionManager _this = null;

        public CookieAndDbSessionManager(IClientStorageProvider clientStorageProvider, IUserManager userManager, ILogger logger)
        {
            _clientStorageProvider = clientStorageProvider;
            _userManager = userManager;
            _logger = logger;
            _this = this;
        }
                
        bool ISessionManager.IsAuthenticatedSession
        {
            get
            {
                var isAuthenticated = false;
                var sessionId = _this.SessionId;

                if (sessionId != null)
                {
                    isAuthenticated = sessionId.EndsWith("1");
                }

                return isAuthenticated;
            }
        }

        string ISessionManager.SessionId
        {
            get
            {
                var sessionId = string.Empty;

                try
                {
                    sessionId = _clientStorageProvider.Read(new ReadClientStorageRequest() { Key = SESSION_COOKIE_NAME }).Value;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("An exception occurred attempting to read the session cookie.", e);
                }

                return sessionId;
            }
        }

        SessionAuthenticationResponse ISessionManager.AuthenticateSession(SessionAuthenticationRequest sessionAuthenticationRequest)
        {
            SessionAuthenticationResponse sessionAuthenticationResponse = null;

            try
            {
                if (_userManager.Authenticate(new UserAuthenticationRequest(sessionAuthenticationRequest.Username, sessionAuthenticationRequest.Password)).Authenticated)
                {
                    var newSessiond = "{0}1".FormatWith(sessionAuthenticationRequest.SessionId.Substring(0, sessionAuthenticationRequest.SessionId.Length - 1));
                    _clientStorageProvider.Write(new WriteClientStorageRequest() { Key = SESSION_COOKIE_NAME, Value = newSessiond });
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred attempting to authenticate a session for [{0}]".FormatWith(sessionAuthenticationRequest.Username), e);
            }

            return sessionAuthenticationResponse;
        }

        SessionCreateResponse ISessionManager.CreateSession()
        {
            var sessionCreateResponse = new SessionCreateResponse();

            try
            {
                if (string.IsNullOrEmpty(_this.SessionId))
                {
                    //Create a new session - append a 0 to the session id to indicate that it is unauthenticated
                    var newSessionId = "{0}0".FormatWith(Guid.NewGuid().ToString());
                    sessionCreateResponse = newSessionId;

                    _clientStorageProvider.Write(new WriteClientStorageRequest() { Key = SESSION_COOKIE_NAME, Value = newSessionId });
                }
                else
                {
                    sessionCreateResponse = _this.SessionId;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a CookieAndDbSessionManager CreateSession call.", e);
            }

            return sessionCreateResponse;
        }

        SessionInformationResponse ISessionManager.RetrieveSessionInformation(SessionInformationRequest sessionInformationRequest)
        {
            throw new NotImplementedException();
        }

        void ISessionManager.RevokeSessionAuthentication(RevokeSessionAuthenticationRequest revokeSessionAuthenticationRequest)
        {
            try
            {
                var unauthenticatedSessionId = "{0}0".FormatWith(revokeSessionAuthenticationRequest.AuthenticatedSessionId.Substring(0, revokeSessionAuthenticationRequest.AuthenticatedSessionId.Length - 1));
                _clientStorageProvider.Write(new WriteClientStorageRequest() { Key = SESSION_COOKIE_NAME, Value = unauthenticatedSessionId });
            }
            catch (Exception e)
            {
                _logger.Log(Domain.LogSeverity.Error, "An exception occurred attempting to revoke session authentication. Swalling exception and clearing session cookie.", e);
                _clientStorageProvider.Clear(new ClearClientStorageRequest() { Key = SESSION_COOKIE_NAME });
            }
        }
    }
}

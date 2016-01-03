using System;
using System.Collections.Generic;
using System.Linq;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain.Session.DataAccess;
using WhatsHoppening.Domain.Session.SessionInformation;

namespace WhatsHoppening.Providers.SessionManager.DataAccess
{
    public class MockedSessionDataAccessProvider : ISessionDataAccessProvider
    {
        private static Dictionary<string, Dictionary<SessionInformationType, object>> _session = null;
        private readonly ISessionDataAccessProvider _this = null;
        private readonly IConfigurationProvider _configurationProvider = null;

        public MockedSessionDataAccessProvider(IConfigurationProvider configurationProvider)
        {
            Initialise();

            _this = this;
            _configurationProvider = configurationProvider;
        }

        private static void Initialise()
        {
            if (_session == null)
            {
                _session = new Dictionary<string, Dictionary<SessionInformationType, object>>();
            }
        }

        void ISessionDataAccessProvider.Clear()
        {
            _session.Clear();
        }

        void ISessionDataAccessProvider.Clear(ClearSessionRequest clearSessionRequest)
        {
            _session.Remove(clearSessionRequest.SessionId);
        }

        void ISessionDataAccessProvider.Create(SessionCreateRequest sessionCreateRequest)
        {
            try
            {
                if (!_session.Keys.Contains(sessionCreateRequest.SessionId))
                {
                    _session.Add(sessionCreateRequest.SessionId, new Dictionary<SessionInformationType, object>());
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a MockedSessionDataAccessProvider.Create request", e);
            }
        }

        SessionReadResponse<T> ISessionDataAccessProvider.Read<T>(SessionReadRequest sessionReadRequest)
        {
            var sessionReadResponse = new SessionReadResponse<T>();

            try
            {
                if (_session.ContainsKey(sessionReadRequest.SessionId))
                {
                    var sessionInformation = _session[sessionReadRequest.SessionId];

                    if ((DateTime)sessionInformation[SessionInformationType.SessionExpiry] < DateTime.Now)
                    {
                        _session.Remove(sessionReadRequest.SessionId);
                        sessionReadResponse.Data = default(T);
                    }
                    else
                    {
                        var unparsedData = sessionInformation.FirstOrDefault(x => x.Key == sessionReadRequest.SessionInformationType).Value;
                        sessionReadResponse.Data = (T)unparsedData;
                    }                    
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a MockedSessionDataAccessProvider.Read request", e);
            }

            return sessionReadResponse;
        }

        void ISessionDataAccessProvider.Remove(SessionRemoveRequest sessionRemoveRequest)
        {
            try
            {
                if (_session.ContainsKey(sessionRemoveRequest.SessionId))
                {
                    _session[sessionRemoveRequest.SessionId].Remove(sessionRemoveRequest.SessionInformationType);

                    if (_session[sessionRemoveRequest.SessionId].Count == 0)
                    {
                        _session.Remove(sessionRemoveRequest.SessionId);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a MockedSessionDataAccessProvider.Remove request", e);
            }
        }

        SessionStoreResponse<T> ISessionDataAccessProvider.Store<T>(SessionStoreRequest<T> sessionStoreRequest)
        {
            SessionStoreResponse<T> sessionStoreResponse = null;

            try
            {
                if (!_session.ContainsKey(sessionStoreRequest.SessionId))
                {
                    _session.Add(sessionStoreRequest.SessionId, new Dictionary<SessionInformationType, object>());
                    _session[sessionStoreRequest.SessionId].Add(SessionInformationType.SessionExpiry,
                        DateTime.Now.AddSeconds(int.Parse(_configurationProvider.Read("SessionExpirySeconds").Value)));
                }

                if (!_session[sessionStoreRequest.SessionId].ContainsKey(SessionInformationType.SessionExpiry))
                {
                    //Odd scenario where session created without expiry
                    _session[sessionStoreRequest.SessionId].Add(SessionInformationType.SessionExpiry,
                        DateTime.Now.AddSeconds(int.Parse(_configurationProvider.Read("SessionExpirySeconds").Value)));
                }

                if (_session[sessionStoreRequest.SessionId].ContainsKey(sessionStoreRequest.SessionInformationType))
                {
                    _session[sessionStoreRequest.SessionId][sessionStoreRequest.SessionInformationType] = sessionStoreRequest.Data;
                }
                else
                {
                    _session[sessionStoreRequest.SessionId].Add(sessionStoreRequest.SessionInformationType, sessionStoreRequest.Data);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a MockedSessionDataAccessProvider.Store request", e);
            }

            return sessionStoreResponse;
        }

        void ISessionDataAccessProvider.Update(SessionUpdateRequest sessionUpdateRequest)
        {
            try
            {
                if (_session.Keys.Contains(sessionUpdateRequest.OldSessionId))
                {
                    var copiedSessionData = _session[sessionUpdateRequest.OldSessionId];

                    // We add the new session first incase some shit goes down between this and removing the old one.
                    _session.Add(sessionUpdateRequest.NewSessionId, copiedSessionData);
                    _session.Remove(sessionUpdateRequest.OldSessionId);
                }
                else
                {
                    _this.Create(new SessionCreateRequest() { SessionId = sessionUpdateRequest.NewSessionId });
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred during a MockedSessionDataAccessProvider.Update request", e);
            }
        }
    }
}

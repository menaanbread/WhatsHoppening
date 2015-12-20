using WhatsHoppening.Domain.Session;
using WhatsHoppening.Domain.Session.SessionInformation;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ISessionManager
    {
        string SessionId { get; }
        bool IsAuthenticatedSession { get; }

        SessionCreateResponse CreateSession();
        SessionAuthenticationResponse AuthenticateSession(SessionAuthenticationRequest sessionAuthenticationRequest);
        void RevokeSessionAuthentication(RevokeSessionAuthenticationRequest revokeSessionAuthenticationRequest);
        SessionInformationResponse RetrieveSessionInformation(SessionInformationRequest sessionInformationRequest);
    }
}

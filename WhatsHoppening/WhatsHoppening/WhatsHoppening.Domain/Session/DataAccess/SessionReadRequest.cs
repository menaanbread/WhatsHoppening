using WhatsHoppening.Domain.Session.SessionInformation;

namespace WhatsHoppening.Domain.Session.DataAccess
{
    public class SessionReadRequest
    {
        public string SessionId { get; set; }
        public SessionInformationType SessionInformationType { get; set; }
    }
}

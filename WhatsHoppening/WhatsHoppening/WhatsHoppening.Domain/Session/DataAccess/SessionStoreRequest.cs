using WhatsHoppening.Domain.Session.SessionInformation;

namespace WhatsHoppening.Domain.Session.DataAccess
{
    public class SessionStoreRequest<T>
    {
        public string SessionId { get; set; }
        public SessionInformationType SessionInformationType { get; set; }
        public T Data { get; set; }
    }
}

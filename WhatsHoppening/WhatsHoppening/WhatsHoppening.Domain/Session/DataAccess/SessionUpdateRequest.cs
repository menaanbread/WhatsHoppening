namespace WhatsHoppening.Domain.Session.DataAccess
{
    public class SessionUpdateRequest
    {
        public string OldSessionId { get; set; }
        public string NewSessionId { get; set; }
    }
}

using System;

namespace WhatsHoppening.Domain.Session
{
    public class SessionCreateResponse
    {
        public static implicit operator SessionCreateResponse(string sessionid)
        {
            return new SessionCreateResponse() { SessionId = sessionid };
        }

        public string SessionId { get; set; }
    }
}

namespace WhatsHoppening.Domain.Session.DataAccess
{
    public class SessionReadResponse<T>
    {
        public SessionReadResponse()
        {
            Data = default(T);
        }

        public T Data { get; set; }
    }
}

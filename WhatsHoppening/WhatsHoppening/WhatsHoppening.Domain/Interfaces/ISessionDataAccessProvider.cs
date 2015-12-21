using WhatsHoppening.Domain.Session.DataAccess;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ISessionDataAccessProvider
    {
        SessionStoreResponse<T> Store<T>(SessionStoreRequest<T> sessionStoreRequest);
        SessionReadResponse<T> Read<T>(SessionReadRequest sessionReadRequest);
        void Remove(SessionRemoveRequest sessionRemoveRequest);
        void Clear();
        void Clear(ClearSessionRequest clearSessionRequest);
        void Create(SessionCreateRequest sessionCreateRequest);
        void Update(SessionUpdateRequest sessionUpdateRequest);
    }
}

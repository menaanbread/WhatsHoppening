using WhatsHoppening.Domain.Caching;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ICachingProvider
    {
        CacheReadResponse<T> Retrieve<T>(CacheReadRequest cacheRequest);
        CacheWriteResponse<T> Write<T>(CacheWriteRequest<T> cacheWriteRequest);
        void Clear();
        void Clear(CacheClearRequest cacheClearRequest);
    }
}

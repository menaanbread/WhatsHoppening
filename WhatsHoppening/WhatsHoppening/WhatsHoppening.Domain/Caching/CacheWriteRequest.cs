using System;

namespace WhatsHoppening.Domain.Caching
{
    public class CacheWriteRequest<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
        public CacheScope Scope { get; set; }
        public DateTime Expiry { get; set; }
    }
}

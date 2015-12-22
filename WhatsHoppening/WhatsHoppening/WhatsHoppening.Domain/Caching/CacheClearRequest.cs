namespace WhatsHoppening.Domain.Caching
{
    public class CacheClearRequest
    {
        public string Key { get; set; }
        public CacheScope Scope { get; set; }
    }
}

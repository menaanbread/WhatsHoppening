namespace WhatsHoppening.Domain.Caching
{
    public class CacheReadRequest
    {
        public string Key { get; set; }
        public CacheScope Scope { get; set; }
    }
}

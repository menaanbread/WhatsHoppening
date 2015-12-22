using System;
using System.Collections.Concurrent;
using WhatsHoppening.Domain.Caching;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.Caching
{
    public class CachingProvider : ICachingProvider
    {
        private class CacheItem
        {
            public object Value { get; set; }
            public DateTime Expiry { get; set; }
        }

        private const int INITIAL_CAPACITY = 101;

        private ConcurrentDictionary<string, CacheItem> _localCache = null;
        private static ConcurrentDictionary<string, CacheItem> _staticCache = null;

        private readonly IConfigurationProvider _configurationProvider = null;
        private readonly ICachingProvider _this = null;

        public CachingProvider(IConfigurationProvider configurationProvider)
        {
            var concurrencyLevel = Environment.ProcessorCount * 2;

            _this = this;
            _configurationProvider = configurationProvider;
            _localCache = new ConcurrentDictionary<string, CacheItem>(concurrencyLevel, INITIAL_CAPACITY);

            Initialise(concurrencyLevel);
        }
        
        static void Initialise(int concurrencyLevel)
        {
            if (_staticCache == null)
            {
                _staticCache = new ConcurrentDictionary<string, CacheItem>(concurrencyLevel, INITIAL_CAPACITY);
            }
        }

        void ICachingProvider.Clear()
        {
            _localCache.Clear();
            _staticCache.Clear();
        }

        void ICachingProvider.Clear(CacheClearRequest cacheClearRequest)
        {
            CacheItem removedItem;

            switch (cacheClearRequest.Scope)
            {
                case CacheScope.Local:
                    _localCache.TryRemove(cacheClearRequest.Key, out removedItem);
                    break;
                case CacheScope.Static:
                case CacheScope.Global:
                    _staticCache.TryRemove(cacheClearRequest.Key, out removedItem);
                    break;
            }
        }

        CacheReadResponse<T> ICachingProvider.Retrieve<T>(CacheReadRequest cacheRequest)
        {
            CacheReadResponse<T> cacheReadResponse = null;

            try
            {
                cacheReadResponse = new CacheReadResponse<T>();

                switch (cacheRequest.Scope)
                {
                    case CacheScope.Local:
                        if (_localCache[cacheRequest.Key] != null) {
                            if (_localCache[cacheRequest.Key].Expiry > DateTime.Now)
                            {
                                cacheReadResponse.Value = (T)_localCache[cacheRequest.Key].Value;
                            }
                            else
                            {
                                _this.Clear(new CacheClearRequest() { Key = cacheRequest.Key, Scope = CacheScope.Local });   
                            }
                        }
                        break;
                    case CacheScope.Static:
                    case CacheScope.Global:
                        if (_staticCache[cacheRequest.Key] != null)
                        {
                            if (_staticCache[cacheRequest.Key].Expiry > DateTime.Now)
                            {
                                cacheReadResponse.Value = (T)_staticCache[cacheRequest.Key].Value;
                            }
                            else
                            {
                                _this.Clear(new CacheClearRequest() { Key = cacheRequest.Key, Scope = CacheScope.Static });
                            }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred calling CachingProvider.Retrieve", e);
            }

            return cacheReadResponse;
        }

        CacheWriteResponse<T> ICachingProvider.Write<T>(CacheWriteRequest<T> cacheWriteRequest)
        {
            CacheWriteResponse<T> cacheWriteResponse = null;

            try
            {
                var itemToCache = new CacheItem() { Expiry = cacheWriteRequest.Expiry, Value = cacheWriteRequest.Value };

                switch (cacheWriteRequest.Scope)
                {
                    case CacheScope.Local:
                        _localCache.AddOrUpdate(cacheWriteRequest.Key,
                            itemToCache,
                            (x, y) => itemToCache);
                        break;
                    case CacheScope.Static:
                    case CacheScope.Global:
                        _staticCache.AddOrUpdate(cacheWriteRequest.Key,
                            itemToCache,
                            (x, y) => itemToCache);
                        break;
                }

                cacheWriteResponse.Item = (T)itemToCache.Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred calling CachingProvider.Write", e);
            }

            return cacheWriteResponse;
        }
    }
}

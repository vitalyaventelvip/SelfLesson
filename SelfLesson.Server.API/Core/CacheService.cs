using Microsoft.Extensions.Caching.Memory;
using SelfLesson.Server.API.Interfaces;
using SelfLesson.Server.API.Models;
using System;
using System.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace SelfLesson.Server.API.Core
{
    public class CacheService : ICache
    {
        private readonly IMemoryCache memoryCache;
        private MemoryCacheEntryOptions cacheEntryOptions;
        private readonly object cacheLock = new object ();

        private readonly static string _CacheKey = CacheKeys.Products;
        private readonly static string _CacheOptionsKey = $"{_CacheKey}:cacheOptions";
        private CacheOptions _CacheOptions;

        public CacheService(IMemoryCache memoryCache)
        {
            _CacheOptions = new CacheOptions(ConfigurationManager.AppSettings[$"{_CacheOptionsKey}:expirationTime"]);
            this.memoryCache = memoryCache;
            cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(_CacheOptions.ExpirationTime);
        }

        public T GetOrUpdate<T>(string key, Func<T> func)
        {
            object cachEntry;
            bool isCached;

            var cacheKey = $"{_CacheKey}:{key}";

            lock (cacheLock)
            {
                isCached = memoryCache.TryGetValue(cacheKey, out cachEntry);
            }

            if (!isCached)
            {
                cachEntry = func();

                lock (cacheLock)
                {
                    memoryCache.Set(cacheKey, cachEntry, cacheEntryOptions);
                }
            }

            return (T)cachEntry;
        }
    }
}

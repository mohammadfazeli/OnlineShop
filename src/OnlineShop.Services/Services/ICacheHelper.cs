using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Services.Contracts;
using System;

namespace OnlineShop.Services.Services
{
    public class CacheHelper:ICacheHelper
    {
        public IMemoryCache _cache { set; get; }

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add<T>(T o,string key)
        {
            T cacheEntry;

            // Look for cache key.
            if(!_cache.TryGetValue(key,out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = o;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(7200)); // 2h

                // Save data in cache.
                _cache.Set(key,cacheEntry,cacheEntryOptions);
            }
        }
    }
}
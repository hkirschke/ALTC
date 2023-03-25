using ALTC.Application.Interfaces.Infrastructures;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;

namespace ALTC.Infra.Db.Memory.Cache.Repositories
{
    public sealed class MemoryCacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task SetAsync<T>(string cacheName, T value, int hoursExpiration = 1)
        {
            if (string.IsNullOrEmpty(cacheName) || value is null) { return; }

            var cacheItem = new CacheItem(cacheName, value);

            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(hoursExpiration)
            };

            await Task.Run(() => _memoryCache.Set(cacheItem, cacheItemPolicy));
        }


        public async Task<object?> GetAsync<T>(string cacheName)
        {
            if (string.IsNullOrEmpty(cacheName)) { return null; }

            var item = await Task.FromResult(_memoryCache.Get(cacheName));

            return item;
        }


        public async Task<bool> RemoveAsync<T>(string cacheName)
        {
            if (string.IsNullOrEmpty(cacheName)) { return false; }

            await Task.Run(() => _memoryCache.Remove(cacheName));

            return true;
        }
    }
}
using Microsoft.Extensions.Caching.Distributed;
using MyBlog.Application.Abstractions.Caching;
using System.Text.Json;

namespace MyBlog.Infrastructure.Services.Caching.Distributed
{
    public class DistributedCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Add(string key, object value)
        {
            var data = JsonSerializer.Serialize(value);
            _distributedCache.SetString(key, data);
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public bool TryGetValue<T>(string key, out T? value)
        {
            var cachedData = _distributedCache.GetString(key);

            if (cachedData == null)
            {
                value = default;
                return false;
            }

            value = JsonSerializer.Deserialize<T>(cachedData);
            return true;
        }
    }
}

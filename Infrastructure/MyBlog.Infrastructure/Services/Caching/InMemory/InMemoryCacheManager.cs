using Microsoft.Extensions.Caching.Memory;
using MyBlog.Application.Abstractions.Caching.InMemory;

namespace MyBlog.Infrastructure.Services.Caching.InMemory
{
    public class InMemoryCacheManager : IInMemoryCacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public bool TryGetValue<T>(string key, out T value) where T : class
        {
            return _memoryCache.TryGetValue(key, out value);
        }
    }
}

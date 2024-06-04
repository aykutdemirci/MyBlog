using MyBlog.Application.Abstractions.Caching;

namespace MyBlog.Infrastructure.Services.Caching
{
    public class CacheService : ICacheService
    {
        private readonly ICacheManager _cacheManager;

        public CacheService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void Add(string key, object value)
        {
            _cacheManager.Add(key, value);
        }

        public void Clear()
        {
            _cacheManager.Clear();
        }

        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        public bool TryGetValue<T>(string key, out T value) where T : class
        {
            return _cacheManager.TryGetValue(key, out value);
        }
    }
}

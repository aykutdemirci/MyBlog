namespace MyBlog.Application.Abstractions.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value);

        bool TryGetValue<T>(string key, out T value) where T : class;

        void Remove(string key);
    }
}

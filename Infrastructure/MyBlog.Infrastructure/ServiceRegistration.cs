using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Abstractions.Caching.InMemory;
using MyBlog.Application.Abstractions.Storage;
using MyBlog.Infrastructure.Enums;
using MyBlog.Infrastructure.Services.Caching.InMemory;
using MyBlog.Infrastructure.Services.Storage;

namespace MyBlog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddCache(this IServiceCollection serviceCollection, CachingType cachingType)
        {
            switch (cachingType)
            {
                case CachingType.InMemory:
                    serviceCollection.AddMemoryCache();
                    serviceCollection.AddSingleton<IInMemoryCacheManager, InMemoryCacheManager>();
                    break;
                case CachingType.Distributed:
                    //todo redis eklenebilir
                    break;
                default:
                    serviceCollection.AddMemoryCache();
                    break;
            }
        }
    }
}

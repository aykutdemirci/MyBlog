using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Abstractions.Services.AppUser;
using MyBlog.Application.Abstractions.Storage;
using MyBlog.Infrastructure.Services.AppUserService;
using MyBlog.Infrastructure.Services.Storage;

namespace MyBlog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAppUserService, AppUserService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}

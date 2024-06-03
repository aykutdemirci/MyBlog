using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Services;
using MyBlog.Infrastructure.Services;

namespace MyBlog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}

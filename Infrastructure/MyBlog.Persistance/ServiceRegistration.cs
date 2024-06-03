using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Abstractions;
using MyBlog.Application.Repositories;
using MyBlog.Persistance.Concretes;
using MyBlog.Persistance.Contexts;
using MyBlog.Persistance.Repositories;

namespace MyBlog.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerivces(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyBlogDbContext>(opts => opts.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            serviceCollection.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            serviceCollection.AddScoped<IBlogReadRepository, BlogReadRepository>();
            serviceCollection.AddScoped<IBlogWriteRepository, BlogWriteRepository>();

            serviceCollection.AddScoped<IPostReadRepository, PostReadRepository>();
            serviceCollection.AddScoped<IPostWriteRepository, PostWriteRepository>();

            serviceCollection.AddTransient<IPostService, PostService>();
        }
    }
}
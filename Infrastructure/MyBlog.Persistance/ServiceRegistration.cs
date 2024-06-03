using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Identity;
using MyBlog.Persistance.Contexts;
using MyBlog.Persistance.Repositories;

namespace MyBlog.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerivces(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyBlogDbContext>(opts => opts.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MyBlogDbContext>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();

            serviceCollection.AddScoped<IBlogRepository, BlogRepository>();

            serviceCollection.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
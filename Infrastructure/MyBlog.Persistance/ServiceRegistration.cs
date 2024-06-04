using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Identity;
using MyBlog.Persistance.Contexts;
using MyBlog.Persistance.Repositories;
using MyBlog.Persistance.Services.AppUserService;
using MyBlog.Persistance.Services.Author;

namespace MyBlog.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceSerivces(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyBlogDbContext>(opts => opts.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddIdentity<AppUser, AppRole>(opts =>
            {
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<MyBlogDbContext>();

            serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();
            serviceCollection.AddScoped<IBlogRepository, BlogRepository>();
            serviceCollection.AddScoped<IPostRepository, PostRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAppUserService, AppUserService>();
            serviceCollection.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
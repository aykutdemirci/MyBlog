using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

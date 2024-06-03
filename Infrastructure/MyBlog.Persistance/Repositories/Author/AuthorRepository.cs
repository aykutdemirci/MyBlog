using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

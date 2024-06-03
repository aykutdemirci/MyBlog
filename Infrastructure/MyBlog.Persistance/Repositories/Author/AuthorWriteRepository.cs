using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

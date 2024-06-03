using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class BlogReadRepository : ReadRepository<Blog>, IBlogReadRepository
    {
        public BlogReadRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

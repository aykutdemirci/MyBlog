using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class PostReadRepository : ReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(MyBlogDbContext dbContext) : base(dbContext)
        {

        }
    }
}

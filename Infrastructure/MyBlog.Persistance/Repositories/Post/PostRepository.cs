using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(MyBlogDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance.Repositories
{
    public sealed class PostWriteRepository : WriteRepository<Post>, IPostWriteRepository
    {
        public PostWriteRepository(MyBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}

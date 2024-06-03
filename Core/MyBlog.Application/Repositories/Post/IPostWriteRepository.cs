using MyBlog.Domain.Entities;

namespace MyBlog.Application.Repositories
{
    public interface IPostWriteRepository : IWriteRepository<Post>
    {
    }
}

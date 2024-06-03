using MyBlog.Domain.Entities;

namespace MyBlog.Application.Abstractions
{
    public interface IPostService
    {
        List<Post> GetPosts();
    }
}

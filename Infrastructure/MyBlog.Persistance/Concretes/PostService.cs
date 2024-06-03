using MyBlog.Application.Abstractions;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistance.Concretes
{
    public sealed class PostService : IPostService
    {
        public List<Post> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}

using MyBlog.Domain.Entities.Common;

namespace MyBlog.Domain.Entities
{
    public sealed class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

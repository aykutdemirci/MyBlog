using MyBlog.Domain.Entities.Common;

namespace MyBlog.Domain.Entities
{
    public sealed class Blog : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

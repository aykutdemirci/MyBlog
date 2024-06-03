using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Entities.Common;
using MyBlog.Domain.Entities.Identity;

namespace MyBlog.Persistance.Contexts
{
    public sealed class MyBlogDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Blog> Blogs { get; set; }
    }
}

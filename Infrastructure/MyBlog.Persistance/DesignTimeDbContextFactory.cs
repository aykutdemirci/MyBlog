using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance
{
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyBlogDbContext>
    {
        public MyBlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyBlogDbContext>();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new MyBlogDbContext(optionsBuilder.Options);
        }
    }
}

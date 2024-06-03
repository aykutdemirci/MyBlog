using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Common;
using MyBlog.Persistance.Contexts;
using System.Linq.Expressions;

namespace MyBlog.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MyBlogDbContext _dbContext;

        public ReadRepository(MyBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking) query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);

            if (!tracking) query = query.AsNoTracking();

            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
        }
    }
}

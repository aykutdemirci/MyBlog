using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Common;
using MyBlog.Persistance.Contexts;
using System.Linq.Expressions;

namespace MyBlog.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyBlogDbContext _dbContext;

        public Repository(MyBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Delete(T entity)
        {
            var entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
            return Delete(entity);
        }

        public bool Update(T entity)
        {
            var entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

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

using MyBlog.Domain.Entities.Common;

namespace MyBlog.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entities);

        bool Delete(T entity);

        Task<bool> DeleteAsync(string id);

        bool DeleteRange(List<T> entities);

        bool Update(T entity);

        Task<int> SaveAsync();
    }
}

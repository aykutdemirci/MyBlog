using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Common;

namespace MyBlog.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}

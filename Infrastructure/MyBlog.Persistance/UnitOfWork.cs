using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Repositories;
using MyBlog.Domain.Entities.Common;

namespace MyBlog.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<BaseEntity> _repository;

        public UnitOfWork(IRepository<BaseEntity> repository)
        {
            _repository = repository;
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}

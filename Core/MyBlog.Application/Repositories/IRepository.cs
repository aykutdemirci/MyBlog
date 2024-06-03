using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities.Common;

namespace MyBlog.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}

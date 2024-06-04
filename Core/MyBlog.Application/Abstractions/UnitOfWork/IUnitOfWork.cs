using MyBlog.Application.Repositories;

namespace MyBlog.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }

        IBlogRepository BlogRepository { get; }

        IAuthorRepository AuthorRepository { get; }

        Task<bool> SaveAsync();
    }
}

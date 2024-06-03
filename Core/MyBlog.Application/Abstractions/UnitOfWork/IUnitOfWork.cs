namespace MyBlog.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}

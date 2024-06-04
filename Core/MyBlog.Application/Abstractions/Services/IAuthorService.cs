using MyBlog.Application.ViewModels.Authors;

namespace MyBlog.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<bool> CreateAsync(VmCreateAuthor model);

        Task<List<VmListAuthor>> GetAllAsync();
    }
}

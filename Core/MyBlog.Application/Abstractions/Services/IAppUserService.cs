using MyBlog.Application.ViewModels.AppUser;

namespace MyBlog.Application.Abstractions.Services
{
    public interface IAppUserService
    {
        Task<bool> CreateAsync(VmCreateAppUser model);

        Task<bool> LoginAsync(VmLoginAppUser model);

        Task LogoutAsync();
    }
}

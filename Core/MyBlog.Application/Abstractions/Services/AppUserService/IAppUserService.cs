using MyBlog.Application.ViewModels.AppUser;

namespace MyBlog.Application.Abstractions.Services.AppUser
{
    public interface IAppUserService
    {
        Task<bool> CreateAsync(VmCreateAppUser model);

        Task<bool> LoginAsync(VmLoginAppUser model);
    }
}

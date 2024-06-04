using Microsoft.AspNetCore.Identity;
using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.Exceptions;
using MyBlog.Application.ViewModels.AppUser;
using MyBlog.Domain.Entities.Identity;

namespace MyBlog.Persistance.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateAsync(VmCreateAppUser model)
        {
            var result = await _userManager.CreateAsync(new AppUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                Id = Guid.NewGuid().ToString(),
            }, model.Password);

            if (result.Succeeded)
            {
                return true;
            }

            string errorMessages = string.Join("\n", result.Errors.Select(e => e.Description));

            throw new UserCreateFailedException(errorMessages);
        }

        public async Task<bool> LoginAsync(VmLoginAppUser model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);

            if (appUser == null)
            {
                throw new UserLoginFailedException("E-Posta adresi veya şifre hatalı. Kayıtlı değilseniz lütfen kaydolun");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);

            return signInResult.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

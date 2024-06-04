using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.ViewModels.AppUser;
using System.Security.Claims;
using MyBlog.Application.Abstractions.Services;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(VmCreateAppUser model)
        {
            var response = await _appUserService.CreateAsync(model);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(VmLoginAppUser model)
        {
            var response = await _appUserService.LoginAsync(model);

            if (!response)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _appUserService.LogoutAsync();

            return Ok();
        }
    }
}

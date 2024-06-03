using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Abstractions.Services.AppUser;
using MyBlog.Application.ViewModels.AppUser;

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
    }
}

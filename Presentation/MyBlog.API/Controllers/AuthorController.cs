using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.ViewModels.Authors;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(VmCreateAuthor model)
        {
            var result = await _authorService.CreateAsync(model);

            if (result) return Ok(result);

            return new StatusCodeResult(500);
        }
    }
}

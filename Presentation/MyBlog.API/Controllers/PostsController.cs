using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Abstractions;

namespace MyBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult Posts(IPostService postService)
        {
            var posts = postService.GetPosts();

            return Ok(posts);
        }
    }
}

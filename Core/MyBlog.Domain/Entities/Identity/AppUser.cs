using Microsoft.AspNetCore.Identity;

namespace MyBlog.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
    }
}

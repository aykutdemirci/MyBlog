using System.Runtime.Serialization;

namespace MyBlog.Application.Exceptions
{
    public class UserLoginFailedException : Exception
    {
        public UserLoginFailedException() : base("Login işlemi sırasında bir hata oluştu.")
        {
        }

        public UserLoginFailedException(string? message) : base(message)
        {
        }

        public UserLoginFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

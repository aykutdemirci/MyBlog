namespace MyBlog.Application.Exceptions
{
    public class AuthorCreateFailedException : Exception
    {
        public AuthorCreateFailedException() : base("Yazar kaydetme sırasında bir hata oluştu")
        {

        }

        public AuthorCreateFailedException(string? message) : base(message)
        {
        }
    }
}

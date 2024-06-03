using MyBlog.Application.Abstractions.Storage.Azure;

namespace MyBlog.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        public AzureStorage()
        {
        }
    }
}

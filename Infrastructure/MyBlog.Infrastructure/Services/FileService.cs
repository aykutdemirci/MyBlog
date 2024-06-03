using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Services;

namespace MyBlog.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private const int BUFFER_SIZE = 1024 * 1024;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, BUFFER_SIZE);
                await file.CopyToAsync(fs);
                await fs.FlushAsync();

                return true;
            }
            catch
            {
                //TODO loglama yapılacak
                throw;
            }
        }

        public Task<string> RenameFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task UploadAsync(string filePath, IFormFileCollection files)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            foreach (var file in files)
            {
                var fileNewName = await RenameFileAsync(file.FileName);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);

            }

            throw new NotImplementedException();
        }
    }
}

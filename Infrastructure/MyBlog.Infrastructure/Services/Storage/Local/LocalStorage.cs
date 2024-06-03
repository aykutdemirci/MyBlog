using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Abstractions.Storage.Local;

namespace MyBlog.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {

        private const int BUFFER_SIZE = 1024 * 1024;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
        {
            File.Delete($"{path}\\{fileName}");
        }

        public List<string> GetFiles(string path)
        {
            return new DirectoryInfo(path).GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            return File.Exists($"{path}\\{fileName}");
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            var uploadedFiles = new List<(string fileName, string path)>();

            foreach (var file in files)
            {
                var uploadedFileName = Guid.NewGuid().ToString();
                await CopyFileAsync($"{uploadPath}\\{uploadedFileName}{Path.GetExtension(file.FileName)}", file);

                uploadedFiles.Add((uploadedFileName, $"{path}\\{uploadedFileName}"));
            }

            return uploadedFiles;
        }

        private async Task<bool> CopyFileAsync(string filePath, IFormFile file)
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
    }
}

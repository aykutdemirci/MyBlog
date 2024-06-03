﻿using Microsoft.AspNetCore.Http;

namespace MyBlog.Application.Services
{
    public interface IFileService
    {
        Task UploadAsync(string filePath, IFormFileCollection files);

        Task<string> RenameFileAsync(string fileName);

        Task<bool> CopyFileAsync(string filePath, IFormFile file);
    }
}
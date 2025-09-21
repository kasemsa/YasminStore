using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.ServicesInterfaces;
using YasminStore.Domain.Enums;

namespace YasminStore.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly string _SavePath;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {

            _SavePath = Path.Combine(environment.ContentRootPath + "/wwwroot", "UploadedFiles");

            if (!Directory.Exists(_SavePath))
            {
                Directory.CreateDirectory(_SavePath);
            }

            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> SaveFileAsync(IFormFile file, SystemFileType fileType)
        {

            string path = _SavePath + "/" + $"{Enum.GetName(typeof(SystemFileType), fileType)}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            bool isHttps = _httpContextAccessor.HttpContext!.Request.IsHttps;

            return isHttps
                  ? $"https://{_httpContextAccessor.HttpContext?.Request.Host.Value}/UploadedFiles/{Enum.GetName(typeof(SystemFileType), fileType)}/{filePath.Split('\\').LastOrDefault()}"
                  : $"http://{_httpContextAccessor.HttpContext?.Request.Host.Value}/UploadedFiles/{Enum.GetName(typeof(SystemFileType), fileType)}/{filePath.Split('\\').LastOrDefault()}";
        }
        public async Task<string> SaveFileAndGetPath(IFormFile file)
        {
            var filePath = Path.Combine(_SavePath, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            return filePath;
        }

        public async Task<byte[]> ReadFileAsync(string filePath, SystemFileType fileType)
        {
            var path = _SavePath + '/' + Enum.GetName(typeof(SystemFileType), fileType) + '/' + filePath.Split('/').LastOrDefault();
            return await File.ReadAllBytesAsync(path);
        }
    }
}

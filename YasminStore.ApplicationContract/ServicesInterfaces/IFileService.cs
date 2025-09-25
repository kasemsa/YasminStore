using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Enums;

namespace YasminStore.ApplicationContract.ServicesInterfaces
{
    public interface IFileService
    {
        public Task<string> SaveFileAsync(IFormFile file, SystemFileType fileType);
        public Task<string> SaveFileAndGetPath(IFormFile file);
        public Task<byte[]> ReadFileAsync(string filePath, SystemFileType fileType);
    }
}

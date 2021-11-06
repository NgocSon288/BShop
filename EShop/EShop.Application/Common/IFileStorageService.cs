using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EShop.Application.Common
{
    public interface IFileStorageService
    {
        Task DeleteFileAsync(string fileName);
        Task<string> SaveFileAsync(IFormFile file, string savePath);
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using EShop.Application.Common;
using EShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application
{
    public abstract class BaseService
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public BaseService(IFileStorageService fileStorageService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager)
        {
            _fileStorageService = fileStorageService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        /// <summary>
        /// Thực hiện xóa file được lưu tạm thời trong lúc save database bị lỗi
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        protected async Task RollbackFile(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    await _fileStorageService.DeleteFileAsync(imagePath);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Thực hiện xóa files được lưu tạm thời trong lúc save database bị lỗi
        /// </summary>
        /// <param name="imagePaths"></param>
        /// <returns></returns>
        protected async Task RollbackFile(List<string> imagePaths)
        {
            foreach (var item in imagePaths)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    try
                    {
                        await _fileStorageService.DeleteFileAsync(item);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Lấy ra được User hiện tại đang thực hiện request này.
        /// </summary>
        /// <returns></returns>
        protected async Task<AppUser> GetCurrentUser()
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                return await _userManager.FindByIdAsync(userId);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

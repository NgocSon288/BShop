using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.AppUsers
{
    public interface IAppUserService
    {
        Task<ApiResult<PagedList<AppUserViewModel>>> GetAllBySearch(AppUserSearchRequest request);

        Task<ApiResult<bool>> Register(AppUserRegisterRequest request); 

        Task<ApiResult<string>> Login(AppUserLoginRequest request);

        Task<ApiResult<AppUserAuthenticateViewModel>> Authenticate();

        Task<ApiResult<bool>> VerifyRegisterEmail(Guid userId, string code);
    }
}

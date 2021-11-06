using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace EShop.Web.Interfaces
{
    public interface IAccountApiClient
    { 
        Task<ApiResult<bool>> Register(AppUserRegisterRequest request);

        Task<ApiResult<bool>> CreateAccountVerify(Guid userId, string code);

        Task<ApiResult<string>> Login(AppUserLoginRequest request);

        Task<ApiResult<AppUserAuthenticateViewModel>> Authenticate();
    }
}
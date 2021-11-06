using EShop.ViewModels.AppRoles;
using EShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Application.AppRoles
{
    public interface IAppRoleService
    {
        Task<ApiResult<bool>> Create(AppRoleCreateRequest request);
        Task<ApiResult<bool>> Delete(Guid roleId);
        Task<ApiResult<List<AppRoleViewModel>>> GetAll();
        
        Task<ApiResult<AppRoleViewModel>> GetById(Guid ID);
    }
}
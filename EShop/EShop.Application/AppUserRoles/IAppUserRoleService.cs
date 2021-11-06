using EShop.ViewModels.AppUserRoles;
using EShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Application.AppUserRoles
{
    public interface IAppUserRoleService
    {
        Task<ApiResult<List<AppUserRoleViewModel>>> GetAll();
        Task<ApiResult<bool>> Grant(AppUserRoleGrantRequest request);
        Task<ApiResult<bool>> Revoke(AppUserRoleRevokeRequest request);
    }
}
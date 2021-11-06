using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Interfaces
{
    public interface IAppUserApiClient
    {
        Task<ApiResult<PagedList<AppUserViewModel>>> GetAll(AppUserSearchRequest request);
    }
}

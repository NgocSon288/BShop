using EShop.Application.AppUsers;
using EShop.Utilities.Exceptions;
using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : CustomControllerBase
    {
        public readonly IAppUserService _appUserService;

        public AppUsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet] 
        public async Task<ActionResult> GetAll([FromQuery] AppUserSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiErrorResult<PagedList<AppUserViewModel>> (base.ModelStateErrors(ModelState)));
            }

            try
            {
                var result = await _appUserService.GetAllBySearch(request);

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                if (ex.Status == StatusCodes.Status500InternalServerError)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<PagedList<AppUserViewModel>>(ex.Message));
                }

                return BadRequest(new ApiErrorResult<bool>(ex.Message));
            }
        }
    }
}

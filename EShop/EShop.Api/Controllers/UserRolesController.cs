using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.AppUserRoles;
using EShop.Utilities.Exceptions;
using EShop.ViewModels.AppUserRoles;
using EShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IAppUserRoleService _appUserRoleService;

        public UserRolesController(IAppUserRoleService appUserRoleService)
        {
            _appUserRoleService = appUserRoleService;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _appUserRoleService.GetAll();

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<List<AppUserRoleViewModel>>(ex.Message));
            }
        }

        [HttpPost("Grant")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Grant(AppUserRoleGrantRequest request)
        {
            try
            {
                var result = await _appUserRoleService.Grant(request);

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<bool>(ex.Message));
            }
        }

        [HttpPost("Revoke")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Revoke(AppUserRoleRevokeRequest request)
        {
            try
            {
                var result = await _appUserRoleService.Revoke(request);

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<bool>(ex.Message));
            }
        }
    }
}

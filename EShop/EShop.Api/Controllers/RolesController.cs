using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.AppRoles;
using EShop.Utilities.Exceptions;
using EShop.ViewModels.AppRoles;
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
    public class RolesController : CustomControllerBase
    {
        private readonly IAppRoleService _appRoleService;

        public RolesController(IAppRoleService appRoleService)
        {
            _appRoleService = appRoleService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _appRoleService.GetAll();

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<List<AppRoleViewModel>>(ex.Message));
            }
        }

        [HttpGet("{roleId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetByID(Guid roleId)
        {
            try
            {
                var result = await _appRoleService.GetById(roleId);

                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (EShopException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiErrorResult<AppRoleViewModel>(ex.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create([FromBody]AppRoleCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiErrorResult<bool>(base.ModelStateErrors(ModelState)));
            }

            try
            {
                var result = await _appRoleService.Create(request);

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

        [HttpDelete("{roleId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(Guid roleId)
        {
            try
            {
                var result = await _appRoleService.Delete(roleId);

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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EShop.Application.Common;
using EShop.Data.EF;
using EShop.Data.Entities;
using EShop.Utilities.Constants;
using EShop.Utilities.Exceptions;
using EShop.Utilities.Helpers;
using EShop.Utilities.Models;
using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EShop.ViewModels.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.AppUsers
{
    public class AppUserService : BaseService, IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager; 
        private readonly IFileStorageService _fileStorageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailHelperService _mailHelperService;
        private readonly IConfiguration _configuration;

        public AppUserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IFileStorageService fileStorageService,
            IHttpContextAccessor httpContextAccessor,
            IMailHelperService mailHelperService,
            IConfiguration configuration,
            RoleManager<AppRole> roleManager) :
            base(fileStorageService,
                httpContextAccessor,
                userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileStorageService = fileStorageService;
            _httpContextAccessor = httpContextAccessor;
            _mailHelperService = mailHelperService;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<ApiResult<AppUserAuthenticateViewModel>> Authenticate()
        {
            try
            {
                var user = await base.GetCurrentUser();

                if (user == null)
                {
                    return new ApiErrorResult<AppUserAuthenticateViewModel>("Lỗi xác thực");
                }

                var roles = await _userManager.GetRolesAsync(user);

                return new ApiSuccessResult<AppUserAuthenticateViewModel>(new AppUserAuthenticateViewModel()
                {
                    FullName = user.FullName,
                    Address = user.Address,
                    Avatar = $"{_configuration.GetValue<string>(SystemConstants.BaseUrlServer)}/{user.Avatar}",
                    Dob = user.Dob,
                    Gender = user.Gender,
                    Roles = roles.ToList()
                });
            }
            catch (Exception ex)
            {
                throw new EShopException(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResult<PagedList<AppUserViewModel>>> GetAllBySearch(AppUserSearchRequest request)
        {
            var users = await _userManager.Users
                .ToListAsync();

            if (!string.IsNullOrEmpty(request.Name))
            {
                users = users
                    .Where(x => x.FullName.ToLower().Contains(request.Name.ToLower()))
                    .ToList();
            } 

            var count = users.Count();
            var userDtos = users.Select(x => new AppUserViewModel()
            { 
                FullName = x.FullName,
                Address = x.Address,
                Avatar = x.Avatar,
                Dob = x.Dob,
                Email = x.Email,
                Gender = x.Gender
            }).OrderByDescending(x => x.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

            var pagedListUser = new PagedList<AppUserViewModel>(userDtos, count, request.PageNumber, request.PageSize);

            return new ApiSuccessResult<PagedList<AppUserViewModel>>(pagedListUser); 
        }

        public async Task<ApiResult<string>> Login(AppUserLoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                {
                    return new ApiErrorResult<string>("Tài khoản không tồn tại");
                }

                var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, false, true);

                if (result.IsNotAllowed)
                {
                    return new ApiErrorResult<string>("Tài khoản chưa được xác nhận email");
                }
                else if (result.IsLockedOut)
                {
                    return new ApiErrorResult<string>("Tài khoản bị khóa");
                }
                else if (!result.Succeeded)
                {
                    return new ApiErrorResult<string>("Đăng nhập không đúng");
                }

                // Create Token-Jwt
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.GivenName,user.FullName),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[SystemConstants.AppSettings.TokensKey]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration[SystemConstants.AppSettings.TokensIssuer],
                    _configuration[SystemConstants.AppSettings.TokensIssuer],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);

                return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                throw new EShopException(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResult<bool>> Register(AppUserRegisterRequest request)
        {  
            string avatar = "";

            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user != null)
                {
                    return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
                }

                user = await _userManager.FindByEmailAsync(request.Email);

                if (user != null)
                {
                    return new ApiErrorResult<bool>("Email đã có người sử dụng");
                }
                 
                avatar = await _fileStorageService.SaveFileAsync(request.Avatar, "ImageUploads");

                user = new AppUser()
                {
                    FullName = request.FullName,
                    Dob = request.Dob,
                    Email = request.Email,
                    UserName = request.UserName,
                    Avatar = avatar,
                    Address =  request.Address,
                    CreatedAt = DateTime.Now,
                    CreatedBy ="",
                    Gender=request.Gender.HasValue? request.Gender.Value:Gender.Male,
                    IsDeleted = false,
                    UpdatedAt = DateTime.Now,
                    UpdateBy = ""
                };

                var result = await _userManager.CreateAsync(user, request.PassWord);

                if (!result.Succeeded)
                {
                    await base.RollbackFile(avatar);

                    return new ApiErrorResult<bool>(result.Errors.Select(x => x.Description).ToArray());
                }

                // Cập nhật Role
                var memberRole = await _roleManager.FindByNameAsync("member");
                await _userManager.AddToRoleAsync(user, memberRole.Name);

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                 
                var url = _configuration.GetSection(SystemConstants.Callback.CallbackUrl)
                    .GetValue<string>(SystemConstants.Callback.CreateAccountVerify);
                var callbackUrl = string.Format(url, user.Id, code);

                var keyValueBody = new Dictionary<string, string>()
                {
                    { "name", user.FullName},
                    { "callbackUrl", callbackUrl}
                };
                var mailContent = new MailContent(request.Email, "Xác nhận đăng ký tài khoản", "CreateAccountVerify.html", keyValueBody);

                await _mailHelperService.SendMail(mailContent);

                return new ApiSuccessResult<bool>();
            }
            catch (Exception ex)
            {
                await base.RollbackFile(avatar);
                throw new EShopException(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResult<bool>> VerifyRegisterEmail(Guid userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new EShopException("Không tìm thấy tài khoản", StatusCodes.Status404NotFound);
            }

            if (user.EmailConfirmed)
            {
                throw new EShopException("Tài khoản đã được xác thực", StatusCodes.Status400BadRequest);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            // Xác thực email
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
            {
                return new ApiErrorResult<bool>("Lỗi xác thực");
            }

            return new ApiSuccessResult<bool>();
        }
    }
}

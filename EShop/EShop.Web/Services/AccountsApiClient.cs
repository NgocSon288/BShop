using EShop.ViewModels.AppUsers;
using EShop.ViewModels.Common;
using EShop.ViewModels.SeedWork;
using EShop.Web.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks; 

namespace EShop.Web.Services
{
    public class AccountApiClient : IAccountApiClient
    {
        private readonly HttpClient _httpClient;

        private string baseUrl = "api/Accounts";

        public AccountApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<AppUserAuthenticateViewModel>> Authenticate()
        { 
            try
            {
                var url = $"{baseUrl}/Authenticate";
                var result = await _httpClient.GetAsync(url);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResult<AppUserAuthenticateViewModel>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("lỗi " + ex.Message);
                return null;
            }
        }

        public async Task<ApiResult<bool>> CreateAccountVerify(Guid userId, string code)
        {
            try
            { 
                var queryStringParam = new Dictionary<string, string>()
                {
                    ["userId"] = userId.ToString(),
                    ["code"] = code
                }; 
                string url = QueryHelpers.AddQueryString($"{baseUrl}/CreateAccountVerify", queryStringParam);

                var result = await _httpClient.GetAsync(url);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResult<bool>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("lỗi " + ex.Message);
                return null;
            }
        }

        public async Task<ApiResult<string>> Login(AppUserLoginRequest request)
        {
            try
            {
                var url = $"{baseUrl}/Login";
                var result = await _httpClient.PostAsJsonAsync(url, request);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResult<string>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("lỗi " + ex.Message);
                return null;
            }
        }

        public async Task<ApiResult<bool>> Register(AppUserRegisterRequest request)
        {
            try
            {
                var url = $"{baseUrl}/Register";
                var result = await _httpClient.PostAsJsonAsync(url, request);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResult<bool>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("lỗi " + ex.Message);
                return null;
            }
        }
    }
}

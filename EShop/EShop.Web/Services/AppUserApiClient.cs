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
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class AppUserApiClient : IAppUserApiClient
    {
        private readonly HttpClient _httpClient;

        private string baseUrl = "api/AppUsers";

        public AppUserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<PagedList<AppUserViewModel>>> GetAll(AppUserSearchRequest request)
        {
            try
            {
                var queryStringParam = new Dictionary<string, string>()
                {
                    ["pageNumber"] = request.PageNumber.ToString()
                };

                if (!string.IsNullOrEmpty(request.Name))
                    queryStringParam.Add("name", request.Name);
                string url = QueryHelpers.AddQueryString(baseUrl, queryStringParam);

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResult<PagedList<AppUserViewModel>>>(body);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

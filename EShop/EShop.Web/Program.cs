using Blazored.Toast;
using EShop.Web.Interfaces;
using EShop.Web.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("BackendApiUrl"))
            });

            // Services
            builder.Services.AddTransient<IAccountApiClient, AccountApiClient>();
            builder.Services.AddTransient<IAppUserApiClient, AppUserApiClient>();

            // Blazored Services
            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }
    }
}

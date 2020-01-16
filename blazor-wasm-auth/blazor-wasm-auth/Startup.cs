using System;
using blazor_wasm_auth.Application.Services;
using blazor_wasm_auth.Application.ViewModels;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace blazor_wasm_auth
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddAzureActiveDirectory(
                new Uri($"/config/appsettings.json?{DateTime.Now.Ticks}", UriKind.Relative));

            services.AddTransient<ConfigurationService>();

            services.AddTransient<IndexViewModel>();
            services.AddTransient<UserViewModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}

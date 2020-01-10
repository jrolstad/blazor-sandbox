using System;
using blazor_wasm.Applicaiton;
using Des.Blazor.Authorization.Msal;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace blazor_wasm
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IndexViewModel>();

            services.AddAuthorizationCore();
            var config = new MsalConfig
            {
                Authority = "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47",
                ClientId = "a662ef2a-28ab-42e7-8168-e1929e52183d",
                LoginMode = LoginModes.Redirect
            };
            services.AddAzureActiveDirectory(config);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            
            app.AddComponent<App>("app");
        }
    }

    public class MsalConfig : IMsalConfig
    {
        public string ClientId { get; set; }
        public string Authority { get; set; }
        public LoginModes LoginMode { get; set; }
    }
}

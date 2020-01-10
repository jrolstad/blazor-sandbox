using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace blazor_wasm.Applicaiton
{
    public class IndexViewModel
    {
        private readonly IdentityHttpFactory _factory;

        public IndexViewModel(IdentityHttpFactory factory)
        {
            _factory = factory;
        }
        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public string Error { get; set; }

        public async Task Authenticate()
        {
            try
            {
                var clientId = "a662ef2a-28ab-42e7-8168-e1929e52183d";
                var app = PublicClientApplicationBuilder.Create(clientId)
                    .WithDefaultRedirectUri()
                    .WithHttpClientFactory(_factory)
                    .Build();

                string[] scopes = new string[] { "user.read" };
                var accounts = await app.GetAccountsAsync();
                AuthenticationResult result;
                try
                {
                    result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                        .ExecuteAsync();
                }
                catch (MsalUiRequiredException)
                {
                    result = await app.AcquireTokenInteractive(scopes)
                        .ExecuteAsync();
                }

                this.Name = result.AccessToken;
            }
            catch (Exception e)
            {
                this.Error = e.ToString();
            }
           
        }
    }
}
using System.Net.Http;
using Microsoft.Identity.Client;

namespace blazor_wasm.Applicaiton
{
    public class IdentityHttpFactory:IMsalHttpClientFactory
    {
        private readonly IHttpClientFactory _factory;

        public IdentityHttpFactory(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public HttpClient GetHttpClient()
        {
            return _factory.CreateClient();
        }
    }
}
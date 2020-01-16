using System.Linq;
using System.Threading.Tasks;
using blazor_wasm_auth.Application.Services;
using Des.Blazor.Authorization.Msal;

namespace blazor_wasm_auth.Application.ViewModels
{
    public class IndexViewModel
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ConfigurationService _configurationService;

        public IndexViewModel(IAuthenticationManager authenticationManager,
            ConfigurationService configurationService)
        {
            _authenticationManager = authenticationManager;
            _configurationService = configurationService;
        }

        public string AccessToken { get; set; }

        public async Task GetAccessToken()
        {
            var tokenScope = _configurationService.TokenScope();
            var token = await _authenticationManager.GetAccessTokenAsync(tokenScope);
                
            this.AccessToken = token?.AccessToken ?? "nothing";
        }
    }
}
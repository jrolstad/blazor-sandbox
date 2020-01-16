using System.Threading.Tasks;
using blazor_wasm_auth.Application.Services;
using Des.Blazor.Authorization.Msal;

namespace blazor_wasm_auth.Application.ViewModels
{
    public class LoginStatusViewModel
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ConfigurationService _configurationService;

        public LoginStatusViewModel(IAuthenticationManager authenticationManager,
            ConfigurationService configurationService)
        {
            _authenticationManager = authenticationManager;
            _configurationService = configurationService;
        }

        public async Task SignIn()
        {
            var scopes = _configurationService.TokenScope();
            await _authenticationManager.SignInAsync(scopes);
        }

        public async Task SignOut()
        {
            await _authenticationManager.SignOutAsync();
        }
    }
}
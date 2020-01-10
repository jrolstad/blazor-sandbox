using System;
using System.Linq;
using System.Threading.Tasks;
using Des.Blazor.Authorization.Msal;
using Microsoft.Identity.Client;

namespace blazor_wasm.Applicaiton
{
    public class IndexViewModel
    {
        private readonly IAuthenticationManager _authenticationManager;

        public IndexViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public string Error { get; set; }

        public async Task Authenticate()
        {
            try
            {
                await _authenticationManager.SignInAsync();
                var token = await _authenticationManager.GetAccessTokenAsync();

                this.Name = token.AccessToken;
            }
            catch (Exception e)
            {
                this.Error = e.ToString();
            }
           
        }
    }
}
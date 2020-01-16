using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using blazor_wasm_auth.Application.Services;
using Des.Blazor.Authorization.Msal;
using Microsoft.AspNetCore.Components;

namespace blazor_wasm_auth.Application.ViewModels
{
    public class IndexViewModel
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ConfigurationService _configurationService;
        private readonly HttpClient _httpClient;

        public IndexViewModel(IAuthenticationManager authenticationManager,
            ConfigurationService configurationService,
            HttpClient httpClient)
        {
            _authenticationManager = authenticationManager;
            _configurationService = configurationService;
            _httpClient = httpClient;
        }

        public string AccessToken { get; set; }
        public string ApiUrl { get; set; } = "https://dev.azure.com/jrolstad/_apis/projects?api-version=5.1";
        public string ApiResultCode { get; set; }
        public string ApiRequestAuthorization { get; set; }
        public string ApiResult { get; set; }

        public string Status { get; set; }
        public string Error { get; set; }

        public async Task GetAccessToken()
        {
            try
            {
                this.Error = null;
                this.Status = "Obtaining Token...";

                var tokenScope = _configurationService.TokenScope();
                var token = await _authenticationManager.GetAccessTokenAsync(tokenScope);

                this.AccessToken = token?.AccessToken?.Trim() ?? "nothing";
            }
            catch (Exception e)
            {
                this.Error = e.ToString();
            }
            finally
            {
                this.Status = null;
            }
           
        }

        public async Task CallApiWithAccessToken()
        {
            try
            {
                this.Error = null;
                this.Status = "Calling Api...";
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", this.AccessToken);
                this.ApiRequestAuthorization = _httpClient.DefaultRequestHeaders.Authorization.ToString();

                var result = await _httpClient.GetAsync(this.ApiUrl);
                this.ApiResultCode = result.StatusCode.ToString();
                this.ApiResult = await result.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                this.Error = e.ToString();
            }
            finally
            {
                this.Status = null;
            }
           
        }
    }
}
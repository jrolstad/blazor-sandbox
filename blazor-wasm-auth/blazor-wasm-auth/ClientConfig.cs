using Des.Blazor.Authorization.Msal;

namespace blazor_wasm_auth
{
    public class ClientConfig : IMsalConfig
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public LoginModes LoginMode => LoginModes.Redirect;
    }
}
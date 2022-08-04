using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo.Services
{
    public class AuthService
    {
        private readonly IPublicClientApplication authenticationClient;
        public AuthService()
        {
            authenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
#if WINDOWS
            .WithRedirectUri("http://localhost")
#else
                .WithRedirectUri($"msal{Constants.ClientId}://auth")
#endif
            .Build();
        }

        public async Task<AuthenticationResult> LoginAsync(CancellationToken cancellationToken)
        {
            AuthenticationResult result;
            try
            {
                result = await authenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
#if ANDROID
                    .WithParentActivityOrWindow(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity)
#endif
#if WINDOWS
		.WithUseEmbeddedWebView(false)				
#endif
                    .ExecuteAsync(cancellationToken);
                return result;
            }
            catch (MsalClientException)
            {
                return null;
            }
        }
    }
}

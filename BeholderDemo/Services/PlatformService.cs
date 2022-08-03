using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo.Services
{
    internal class PlatformService
    {
        public static IPublicClientApplication GetIdentityClient(object parentWindow)
        {
            var clientBuilder = PublicClientApplicationBuilder
                .Create(Constants.ApplicationId)
                .WithAuthority(AzureCloudInstance.AzurePublic, "common");

#if ANDROID
            clientBuilder = clientBuilder
                .WithRedirectUri($"msal{Constants.ApplicationId}://auth")
                .WithParentActivityOrWindow(() => parentWindow);
#endif

#if WINDOWS
            clientBuilder = clientBuilder
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient");
#endif

            return clientBuilder.Build();
        }
    }
}

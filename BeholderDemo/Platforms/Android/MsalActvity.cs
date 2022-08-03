using Android.App;
using Android.Content;
using global::Android.App;
using global::Android.Webkit;
using Microsoft.Identity.Client;

namespace BeholderDemo.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal210263d3-d41d-4f8b-8404-bb6e9ff70a93")]
    public class MsalActivity : BrowserTabActivity
    {
    }

}

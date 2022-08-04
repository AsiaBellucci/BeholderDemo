using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo
{
    public static class Constants
    {
        public static readonly string ClientId = "eac9f8bb-1301-45da-90b8-d9e28ab3de55";
        public static readonly string[] Scopes = new[] { "openid", "offline_access", "api://210263d3-d41d-4f8b-8404-bb6e9ff70a93/access_as_user" };
        public static readonly string ServiceUri = "https://app-databook-ccnl-dev.azurewebsites.net";
        //"api://210263d3-d41d-4f8b-8404-bb6e9ff70a93/access_as_user"
    }
}

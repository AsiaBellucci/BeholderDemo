using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo
{
    public static class Constants
    {
        /// <summary>
        /// The base URI for the Datasync service.
        /// </summary>
        public static string ServiceUri = "https://app-databook-ccnl-dev.azurewebsites.net";

        /// <summary>
        /// The application (client) ID for the native app within Azure Active Directory
        /// </summary>
        public static string ApplicationId = "eac9f8bb-1301-45da-90b8-d9e28ab3de55";

        /// <summary>
        /// The list of scopes to request
        /// </summary>
        public static string[] Scopes = new[]
        {
          "api://210263d3-d41d-4f8b-8404-bb6e9ff70a93/access_as_user"
      };
    }
}

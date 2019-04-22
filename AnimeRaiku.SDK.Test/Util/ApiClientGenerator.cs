using AnimeRaiku.SDK.Api;
using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Util
{
    public class ApiClientGenerator
    {
        protected static ApiConfiguration config = new ApiConfiguration()
        {
            BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseURL"]
        };

        protected static IAccessTokenProvider token = null;

        public static ApiClient api = null;

        static ApiClientGenerator()
        {
            var clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            var clientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
            var user = System.Configuration.ConfigurationManager.AppSettings["User"];
            var password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            var authURL = System.Configuration.ConfigurationManager.AppSettings["AuthURL"];

            if (token == null || api == null)
            {
                token = new PasswordProvider(clientId, clientSecret, retry => !retry ? new NetworkCredential(user, password) : null, authURL);
                api = new ApiClient(token, config);
            }
        }
    }
}

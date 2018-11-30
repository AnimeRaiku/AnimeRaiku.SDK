using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using AnimeRaiku.SDK.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimeRaiku.SDK.Test.Auth
{
    [TestClass]
    public class PasswordProviderTest
    {
        [TestMethod]
        public async Task Login()
        {
            var clientId = ConfigurationManager.AppSettings["ClientId"];
            var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            var user = ConfigurationManager.AppSettings["User"];
            var password = ConfigurationManager.AppSettings["Password"];
            var authURL = ConfigurationManager.AppSettings["AuthURL"];

            var pp = new PasswordProvider(clientId, clientSecret, retry => !retry ? new NetworkCredential(user, password) : null, authURL);

            var token = await pp.GetAccessTokenAsync();
            Assert.IsNotNull(token);
        }
    }
}

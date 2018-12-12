using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Entity
{
    [TestClass]
    public class DataProviderTypeTest
    {
        private ApiConfiguration config = new ApiConfiguration()
        {
            BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseURL"]
        };

        private IAccessTokenProvider token = null;

        [TestInitialize]
        public void Init()
        {
            var clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            var clientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
            var user = System.Configuration.ConfigurationManager.AppSettings["User"];
            var password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            var authURL = System.Configuration.ConfigurationManager.AppSettings["AuthURL"];

            token = new PasswordProvider(clientId, clientSecret, retry => !retry ? new NetworkCredential(user, password) : null, authURL);
        }

        [TestMethod]
        public void Index()
        {
            var api = new HttpClient(token, config);
            var a = api.Find<DataProviderType>().Result;

            Assert.IsTrue(a.IsValid);
        }
    }
}

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
    public class DataProviderTest
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
            var api = new ApiClient(token, config);
            var a = api.GetAll<DataProvider>(new Query.QueryExpression() { Page = 1}).Result;

            Assert.IsTrue(a.IsValid);
            Assert.AreEqual(1, a.Meta.Pagination.CurrentPage);

            var a2 = api.GetAll<DataProvider>(new Query.QueryExpression() { Page = 2 }).Result;
            Assert.IsTrue(a2.IsValid);
            Assert.AreEqual(2, a2.Meta.Pagination.CurrentPage);
        }
    }
}

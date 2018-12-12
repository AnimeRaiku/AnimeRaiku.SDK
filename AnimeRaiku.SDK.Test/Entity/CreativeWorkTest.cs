using AnimeRaiku.SDK.Api;
using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Test.Factory;
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
    public class CreativeWorkTest
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
        public void CreateUpdate()
        {
            var api = new ApiClient(token, config);
            CreativeWork p = new CreativeWorkFactory().Create();

            ApiMessage<CreativeWork> r = api.CreativeWork.CreateAsync(p).Result;
            Assert.IsTrue(r.IsValid);
            p.Audience = "DT";
            ApiMessage<CreativeWork> u = api.CreativeWork.UpdateAsync(r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual("DT", p.Audience);
        }

        [TestMethod]
        public void Index()
        {
            var api = new ApiClient(token, config);
            var a = api.CreativeWork.FindAsync().Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var api = new ApiClient(token, config);
            var a = api.CreativeWork.GetByIdAsync("569b90bbc25c66d224ae3eed").Result;

            Assert.IsTrue(a.IsValid);
        }
    }
}

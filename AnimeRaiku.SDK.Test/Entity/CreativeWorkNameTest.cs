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
    public class CreativeWorkNameTest
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
            var a = api.CreativeWork.Name.FindAsync("5c1389a595bde36045440936").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var api = new ApiClient(token, config);
            var a = api.CreativeWork.Name.GetByIdAsync("5c1389a595bde36045440936", "5c1389a38e113f4630782e27").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void CreateUpdate()
        {
            var api = new ApiClient(token, config);
            CreativeWorkName p = new CreativeWorkNameFactory().Create();

            ApiMessage<CreativeWorkName> r = api.CreativeWork.Name.CreateAsync("5c1389a595bde36045440936", p).Result;
            Assert.IsTrue(r.IsValid);
            p.Lang = Languages.EN;
            ApiMessage<CreativeWorkName> u = api.CreativeWork.Name.UpdateAsync("5c1389a595bde36045440936", r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Languages.EN, p.Lang);
        }
    }
}

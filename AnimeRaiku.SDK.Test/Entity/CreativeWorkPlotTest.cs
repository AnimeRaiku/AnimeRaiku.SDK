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
    public class CreativeWorkPlotTest
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
            var a = api.CreativeWork.Plot.FindAsync("5c1389a595bde36045440936").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var api = new ApiClient(token, config);
            var a = api.CreativeWork.Plot.GetByIdAsync("5c1389a595bde36045440936", "5c13a83195bde3604544093f").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void CreateUpdate()
        {
            var api = new ApiClient(token, config);
            Plot p = new CreativeWorkPlotFactory().Create();

            ApiMessage<Plot> r = api.CreativeWork.Plot.CreateAsync("5c1389a595bde36045440936", p).Result;
            Assert.IsTrue(r.IsValid);
            p.Lang = Languages.EN;
            ApiMessage<Plot> u = api.CreativeWork.Plot.UpdateAsync("5c1389a595bde36045440936", r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Languages.EN, p.Lang);
        }
    }
}

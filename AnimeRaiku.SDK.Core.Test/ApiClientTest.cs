using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model.Internal;
using AnimeRaiku.SDK.Query;
using AnimeRaiku.SDK.Auth;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace AnimeRaiku.SDK.Core.Test
{
    [TestClass]
    public class ApiClientTest
    {
        private ApiConfiguration config = new ApiConfiguration()
        {
            BaseUrl = "http://api.animeraiku.test"
        };

        private IAccessTokenProvider token = null;
        [TestInitialize]
        public void Init()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json")
                .Build();
            token = new PasswordProvider(config["CLIENT_ID"], config["CLIENT_SECRET"], retry => new NetworkCredential(config["USER"], config["PASSWORD"]), config["AUTH_URL"]);
        }

       

        [TestMethod]
        public void Index()
        {
            var api = new HttpClient(token, config);
            var a = api.Find<Person>().Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void IndexUser()
        {
            var api = new HttpClient(token, config);
            var a = api.Find<User>().Result;
        }
    } 
}

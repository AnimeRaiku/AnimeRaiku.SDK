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
    public class PersonTest
    {
        private ApiConfiguration config = new ApiConfiguration()
        {
            BaseUrl = "http://api.animeraiku.test"
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
            var api = new HttpClient(token, config);
            Person p = new PersonFactory().Create();

            ApiMessage<Person> r = api.Create(p).Result;
            Assert.IsTrue(r.IsValid);
            p.BirthPlace = "DT";
            ApiMessage<Person> u = api.Update(r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual("DT", p.BirthPlace);
        }

        [TestMethod]
        public void Index()
        {
            var api = new HttpClient(token, config);
            var a = api.Find<Person>().Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var api = new HttpClient(token, config);
            var a = api.Get<Person>("5c0110c9575cc50c20003a82").Result;

            Assert.IsTrue(a.IsValid);
        }

    }
}

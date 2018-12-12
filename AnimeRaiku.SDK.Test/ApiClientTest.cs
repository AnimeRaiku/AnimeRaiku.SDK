using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model.Internal;
using AnimeRaiku.SDK.Query;
using AnimeRaiku.SDK.Auth;
using System.Net;
using AnimeRaiku.SDK.Test.Factory;
using AnimeRaiku.SDK.Api;

namespace AnimeRaiku.SDK.Test
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
            var clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            var clientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
            var user = System.Configuration.ConfigurationManager.AppSettings["User"];
            var password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            var authURL = System.Configuration.ConfigurationManager.AppSettings["AuthURL"];

            token = new PasswordProvider(clientId, clientSecret, retry => !retry ? new NetworkCredential(user, password) : null, authURL);
        }


        /*


        [TestMethod]
        public void CWIndex()
        {
            var api = new ApiClient(token, config);

            QueryExpression qe = new QueryExpression();
            qe.Criteria.AddCondition("name.content", ConditionOperator.Contains, "code geass");

            var a = api.GetAll<CreativeWork>(qe).Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void CWDetail()
        {
            var api = new ApiClient(token, config);
            var a = api.Get<CreativeWork>("569b90bbc25c66d224ae3eed").Result;

            Assert.IsTrue(a.IsValid);
        }
        */
        [TestMethod]
        public void QueryExpressionTest()
        {
            QueryExpression qe = new QueryExpression();
            qe.Criteria.AddCondition("external_sources.url", ConditionOperator.Equals, "https://myanimelist.net/people/7/Eiji_Yanagisawa");
            qe.Criteria.AddCondition("date_start", ConditionOperator.Year, 2010);
            qe.AddOrder("name.content", OrderType.Descending);
            qe.AddOrder("date_start", OrderType.Ascending);
            qe.Page = 2;

            var query = qe.ToString();
            //var api = new ApiClient(token, config);

            //var text = api.GetAll<Person>(qe).Result;
        }
    } 
}

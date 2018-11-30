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
        private Configuration config = new Configuration()
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
        public void CreateUpdate()
        {
            
            var api = new ApiClient(token, config);
            Person p = new Person()
            {
                Slug = "Test",
                BirthDate = DateTime.Now,
                BirthPlace = "CR",
                Blood = "A+",
                DeathDate = DateTime.Now.AddYears(10),
                DeathPlace = "MD",
                Description = new Description[]{
                    new Description() { Content = "Autor", IsVisible = true, Lang = "ES" },
                    new Description() { Content = "Autor2", IsVisible = false, Lang = "EN" }
                },
                Name = new PersonName[]
                {
                    new PersonName(){ Lang = "JA-X", Type = "MAIN", FirstName = "Tomokazu", LastName = "Seki",  IsVisible = true },
                    new PersonName(){ Lang = "JA", Type = "MAIN", FirstName = "智一", LastName = "関",  IsVisible = false }
                },
                CreativeWorks = new PersonCreativeWorks[]{
                    new PersonCreativeWorks(){ Id = "5945695095cc8412e0409759", Type = "voice", Role = "role" }
                },
                ExternalSources = new ExternalSources[]
                {
                    new ExternalSources(){ Id = "MAL:People:1", Type ="MyAnimeList", Url = "https://myanimelist.net/people/1/Tomokazu_Seki" }
                }

            };

            ApiMessage<Person> r = api.Create(p).Result;

            p.BirthPlace = "DT";
            ApiMessage<Person> u = api.Update(r.Data.Id, p).Result;
        }

        [TestMethod]
        public void Index()
        {
            var api = new ApiClient(token, config);
            var a = api.GetAll<Person>().Result;
        }

        [TestMethod]
        public void IndexUser()
        {
            var api = new ApiClient(token, config);
            var a = api.GetAll<User>().Result;
        }

        [TestMethod]
        public void Detail()
        {
            var api = new ApiClient(token, config);
            var a = api.Get<Person>("5991d312aa13003c48001072").Result;
        }

        [TestMethod]
        public void CWIndex()
        {
            var api = new ApiClient(token, config);

            QueryExpression qe = new QueryExpression();
            qe.Criteria.AddCondition("name.content", ConditionOperator.Contains, "code geass");

            var a = api.GetAll<CreativeWork>(qe).Result;
        }

        [TestMethod]
        public void CWDetail()
        {
            var api = new ApiClient(token, config);
            var a = api.Get<CreativeWork>("569b90bbc25c66d224ae3eed").Result;
        }

        [TestMethod]
        public void Lookup()
        {
            var api = new ApiClient(token, config);
            var a = api.Lookup<CreativeWork>("Code Geass lelouch", "Anime").Result;

            var b = api.Lookup<CreativeWork>("Code Geass lelouch", "OVA").Result;

            var c = api.Lookup<CreativeWork>("Code Geass lelouch", "Movie").Result;
        }


        [TestMethod]
        public void QueryExpressionTest()
        {
            QueryExpression qe = new QueryExpression();
            qe.Criteria.AddCondition("external_sources.url", ConditionOperator.Equals, "https://myanimelist.net/people/7/Eiji_Yanagisawa");
            //qe.Criteria.AddCondition("date_start", ConditionOperator.Year, 2010);
            //qe.AddOrder("name.content", OrderType.Descending);
            //qe.AddOrder("date_start", OrderType.Ascending);
            var api = new ApiClient(token, config);

            var text = api.GetAll<Person>(qe).Result;
        }
    } 
}

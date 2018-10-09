using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model.Internal;
using AnimeRaiku.SDK.Query;
using AnimeRaiku.SDK.Auth;

namespace AnimeRaiku.SDK.Test
{
    [TestClass]
    public class ApiClientTest
    {
        private Configuration config = new Configuration()
        {
            BaseUrl = "http://api.animeraiku.test"
        };

        private IAccessTokenProvider token = new StringAccessTokenProvider(@"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6ImY0Y2YwNzQzNjU0MDZhMjY3NTJkNTg3ZDVlNDBmZGZmMTcxMmQzYzRhMDQwODc1OGRkNjM4NjQ0NWYzYTE1NmFhYjEyZDEyNDQ1YWE2YWUyIn0.eyJhdWQiOiIxIiwianRpIjoiZjRjZjA3NDM2NTQwNmEyNjc1MmQ1ODdkNWU0MGZkZmYxNzEyZDNjNGEwNDA4NzU4ZGQ2Mzg2NDQ1ZjNhMTU2YWFiMTJkMTI0NDVhYTZhZTIiLCJpYXQiOjE1MDI2MTY5ODEsIm5iZiI6MTUwMjYxNjk4MSwiZXhwIjoxNTM0MTUyOTgxLCJzdWIiOiIxIiwic2NvcGVzIjpbImVuY3ljbG9wZWRpYTpyZWFkIiwiZW5jeWNsb3BlZGlhOndyaXRlIiwidXNlcjpyZWFkIl19.LVNpPvMZpGdBdz9JoORKbAJoRsixe6leaD_CTUil--ARRMARKhiqfjb0_mtCjnHPGRwZgk4IfC1mPXWAhN54jk60dGfvctADy309KmCkKkpg65-rv_uqhIg9U-uQlT_aWzcVokDLOuOhb6y3RRODnGBRZsSUaam3NYnlIFJghabFzkHUOFFHKz-Nqqq7HO0P1IpAdaDgtuLVEZH3aJl_PUJhn33ZTyW7BbHNqN_wQ9kR1oyl6ido3e4oEILycs8_4QYzQTdgk4HP2Au0Vp1LbPPxNE7PM_Cu4U9U27dGKfpk4jJDMKInuBBiKH1Xmg1e3ENwcO16GUw9RZ554VFgRCm6VR20kABxTU420QYy_eXEDkVzvaAqG5XRUGJADOR8cz3G-XT_5XKocQrIPYjJKNY4ykkHUJvjwP1feOHA0EWfee4omC1WL4vOTv_d_nEmRvBTvoqiCwvaKQCWERswJjPwzxdV8PMJ-UQWZ4JMTRYkGa3yn-UEFkXcgBbifPv5D3R3Ftu-TxWAHgDia4PDrSUUwSqTlzI0bLkWWsfIfTZaXIyIlFJqlvGZZyO3mrcGx0Wjqaq4L1CygRSrTXuz6SqqgogyHc_aOEMVlut3neJj5wCd3JyfSXyRcAVJ9m76xlbjMsgfPmiXtyng0lmaCCPAxiD2KvVrULR2DWlPotY");

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

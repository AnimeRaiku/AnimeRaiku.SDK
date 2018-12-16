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
    public class PersonTest : ApiBaseTest
    {
        [TestMethod]
        public void CreateUpdate()
        {
            Person p = new PersonFactory().Create();

            ApiMessage<Person> r = api.Person.CreateAsync(p).Result;
            Assert.IsTrue(r.IsValid);
            p.BirthPlace = "DT";
            ApiMessage<Person> u = api.Person.UpdateAsync(r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual("DT", p.BirthPlace);
        }

        [TestMethod]
        public void Index()
        {
            var a = api.Person.FindAsync().Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var a = api.Person.GetByIdAsync("5c1375b495bde360460fb6f2").Result;

            Assert.IsTrue(a.IsValid);
        }

    }
}

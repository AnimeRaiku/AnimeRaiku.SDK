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
        public async Task Detail()
        {
            Person p = new PersonFactory().Create();

            ApiMessage<Person> r = await api.Person.CreateAsync(p);

            var a = await api.Person.GetByIdAsync(r.Data.Id);

            Assert.IsTrue(a.IsValid);
        }

    }
}

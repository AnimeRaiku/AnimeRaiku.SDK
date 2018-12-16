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
    public class CreativeWorkTest : ApiBaseTest
    {
        [TestMethod]
        public void CreateUpdate()
        {
            CreativeWork p = new CreativeWorkFactory().Create();

            ApiMessage<CreativeWork> r = api.CreativeWork.CreateAsync(p).Result;
            Assert.IsTrue(r.IsValid);
            p.Audience = Demographics.Shonen;
            ApiMessage<CreativeWork> u = api.CreativeWork.UpdateAsync(r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Demographics.Shonen, p.Audience);
        }

        [TestMethod]
        public void Index()
        {
            var a = api.CreativeWork.FindAsync().Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var a = api.CreativeWork.GetByIdAsync("5c1389a595bde36045440936").Result;

            Assert.IsTrue(a.IsValid);
        }
    }
}

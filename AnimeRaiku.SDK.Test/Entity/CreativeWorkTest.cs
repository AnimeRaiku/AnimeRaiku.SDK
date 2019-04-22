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
        public async Task CreateUpdate()
        {
            CreativeWork p = new CreativeWorkFactory().Create();

            ApiMessage<CreativeWork> r = await api.CreativeWork.CreateAsync(p);
            Assert.IsTrue(r.IsValid);
            p.Audience = Demographics.Shonen;
            ApiMessage<CreativeWork> u = await api.CreativeWork.UpdateAsync(r.Data.Id, p);
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Demographics.Shonen, p.Audience);
        }

        [TestMethod]
        public async Task Index()
        {
            var a =  await api.CreativeWork.FindAsync();

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public async Task Detail()
        {
            CreativeWork p = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> r = await api.CreativeWork.CreateAsync(p);
            var a = await api.CreativeWork.GetByIdAsync(r.Data.Id);

            Assert.IsTrue(a.IsValid);
        }
    }
}

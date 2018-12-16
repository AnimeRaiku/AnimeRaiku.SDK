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
    public class CreativeWorkNameTest : ApiBaseTest
    {
        [TestMethod]
        public void Index()
        {
            CreativeWork p = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> r = api.CreativeWork.CreateAsync(p).Result;

            var a = api.CreativeWork.Name.FindAsync(r.Data.Id).Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            CreativeWork c = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> rc = api.CreativeWork.CreateAsync(c).Result;

            CreativeWorkName p = new CreativeWorkNameFactory().Create();

            ApiMessage<CreativeWorkName> r = api.CreativeWork.Name.CreateAsync(rc.Data.Id, p).Result;

            var a = api.CreativeWork.Name.GetByIdAsync(rc.Data.Id, r.Data.Id).Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void CreateUpdate()
        {
            CreativeWork c = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> rc = api.CreativeWork.CreateAsync(c).Result;

            CreativeWorkName p = new CreativeWorkNameFactory().Create();

            ApiMessage<CreativeWorkName> r = api.CreativeWork.Name.CreateAsync(rc.Data.Id, p).Result;
            Assert.IsTrue(r.IsValid);
            p.Lang = Languages.EN;
            ApiMessage<CreativeWorkName> u = api.CreativeWork.Name.UpdateAsync(rc.Data.Id, r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Languages.EN, p.Lang);
        }
    }
}

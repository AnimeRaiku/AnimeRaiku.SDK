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
    public class CreativeWorkPlotTest : ApiBaseTest
    {
        [TestMethod]
        public async Task Index()   
        {
            CreativeWork c = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> rc = await api.CreativeWork.CreateAsync(c);

            var a = await api.CreativeWork.Plot.FindAsync(rc.Data.Id);

            Assert.IsTrue(a.IsValid);
            Assert.IsTrue(a.Data.Count == c.Plot.Length);
        }

        [TestMethod]
        public async Task Detail()
        {
            CreativeWork c = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> rc = await api.CreativeWork.CreateAsync(c);

            var a = await api.CreativeWork.Plot.GetByIdAsync(rc.Data.Id, rc.Data.Attributes.Plot[0].Id);

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public async Task CreateUpdate()
        {

            CreativeWork c = new CreativeWorkFactory().Create();
            ApiMessage<CreativeWork> rc = await api.CreativeWork.CreateAsync(c);

            Plot p = new CreativeWorkPlotFactory().Create();

            ApiMessage<Plot> r = api.CreativeWork.Plot.CreateAsync(rc.Data.Id, p).Result;
            Assert.IsTrue(r.IsValid);
            p.Lang = Languages.EN;
            ApiMessage<Plot> u = api.CreativeWork.Plot.UpdateAsync(rc.Data.Id, r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Languages.EN, p.Lang);
        }
    }
}

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
        public void Index()
        {
            var a = api.CreativeWork.Plot.FindAsync("5c1389a595bde36045440936").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void Detail()
        {
            var a = api.CreativeWork.Plot.GetByIdAsync("5c1389a595bde36045440936", "5c13a83195bde3604544093f").Result;

            Assert.IsTrue(a.IsValid);
        }

        [TestMethod]
        public void CreateUpdate()
        {
            Plot p = new CreativeWorkPlotFactory().Create();

            ApiMessage<Plot> r = api.CreativeWork.Plot.CreateAsync("5c1389a595bde36045440936", p).Result;
            Assert.IsTrue(r.IsValid);
            p.Lang = Languages.EN;
            ApiMessage<Plot> u = api.CreativeWork.Plot.UpdateAsync("5c1389a595bde36045440936", r.Data.Id, p).Result;
            Assert.IsTrue(u.IsValid);
            Assert.AreEqual(Languages.EN, p.Lang);
        }
    }
}

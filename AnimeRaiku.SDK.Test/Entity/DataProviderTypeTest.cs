using AnimeRaiku.SDK.Api;
using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
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
    public class DataProviderTypeTest : ApiBaseTest
    {
        [TestMethod]
        public void Index()
        {
            var a = api.DataProviderType.FindAsync().Result;

            Assert.IsTrue(a.IsValid);
        }
    }
}

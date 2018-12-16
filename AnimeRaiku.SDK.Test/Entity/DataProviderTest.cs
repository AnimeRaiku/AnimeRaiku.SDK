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
    public class DataProviderTest : ApiBaseTest
    {
        [TestMethod]
        public void Index()
        {
            var a = api.DataProvider.FindAsync(new Query.QueryExpression() { Page = 1}).Result;

            Assert.IsTrue(a.IsValid);
            Assert.AreEqual(1, a.Meta.Pagination.CurrentPage);

            var a2 = api.DataProvider.FindAsync(new Query.QueryExpression() { Page = 2 }).Result;
            Assert.IsTrue(a2.IsValid);
            Assert.AreEqual(2, a2.Meta.Pagination.CurrentPage);
        }
    }
}

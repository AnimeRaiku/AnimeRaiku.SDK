using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Entity
{
    [TestClass]
    public class LikeTest : ApiBaseTest
    {
        [TestMethod]
        public void Index()
        {
            var a = api.User.Like.FindAsync("5c1389a595bde36045440936").Result;

            Assert.IsTrue(a.IsValid);
        }
    }
}

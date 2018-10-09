using AnimeRaiku.SDK.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Core.Test
{
    [TestClass]

    public class AuthTest
    {
        [TestMethod]
        public async Task Password()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json")
                .Build();

            var token = await new PasswordProvider(config["CLIENT_ID"], config["CLIENT_SECRET"], () => new NetworkCredential(config["USER"], config["PASSWORD"]), config["AUTH_URL"]).GetAccessTokenAsync();

            Assert.IsNotNull(token?.AccessToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Auth
{
    public class StringAccessTokenProvider : IAccessTokenProvider
    {
        private String accesstoken;

        public StringAccessTokenProvider(String accesstoken)
        {
            this.accesstoken = accesstoken;
        }
#pragma warning disable CS1998 // Como hereda de IAccess debe ser asincrono
        public async Task<TokenInfo> GetAccessTokenAsync()
        {
            return new TokenInfo() { AccessToken = accesstoken };
        }
#pragma warning restore CS1998  
    }
}

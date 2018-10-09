using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Auth
{
    public class AnonymousAccessTokenProvider : IAccessTokenProvider
    {
#pragma warning disable CS1998 // Como hereda de IAccess debe ser asincrono
        public async Task<TokenInfo> GetAccessTokenAsync()
        {
            return new TokenInfo();
        }
#pragma warning restore CS1998  
    }
}

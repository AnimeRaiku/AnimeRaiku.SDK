using AnimeRaiku.SDK.Auth.Entity;
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
        public async Task<TokenInfo> GetAccessTokenAsync()
        {
            return await Task.FromResult(new TokenInfo() { AccessToken = accesstoken });
        } 
    }
}

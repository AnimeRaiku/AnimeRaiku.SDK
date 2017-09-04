using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Auth
{
    public class StringAccessTokenProvider : IAccessTokenProvider
    {
        private String accesstoken;

        public StringAccessTokenProvider(String accesstoken)
        {
            this.accesstoken = accesstoken;
        }

        public string GetAccessToken()
        {
            return accesstoken;
        }
    }
}

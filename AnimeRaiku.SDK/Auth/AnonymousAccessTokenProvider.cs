using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Auth
{
    public class AnonymousAccessTokenProvider : IAccessTokenProvider
    {
        public string GetAccessToken()
        {
            return null;
        }
    }
}

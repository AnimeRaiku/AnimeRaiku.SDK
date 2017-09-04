using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Auth
{
    public interface IAccessTokenProvider
    {
        String GetAccessToken();
    }
}

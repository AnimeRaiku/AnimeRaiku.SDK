using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Api.Internal
{
    public class LikeClient : BaseChildReadClient<User, Like>
    {
        internal LikeClient(HttpClient httpClient)
        {
            childEntity = "Like";
            this.httpClient = httpClient;
        }
    }
}

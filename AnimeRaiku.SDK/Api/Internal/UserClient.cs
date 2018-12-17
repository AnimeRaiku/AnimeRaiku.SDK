using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Api.Internal
{
    public class UserClient : BaseReadClient<User>
    {
        internal UserClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private LikeClient like;
        public LikeClient Like
        {
            get
            {
                if (like == null)
                    like = new LikeClient(httpClient);
                return like;
            }
        }
    }
}

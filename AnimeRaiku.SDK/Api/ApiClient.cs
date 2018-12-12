using AnimeRaiku.SDK.Api.Internal;
using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Api
{
    public class ApiClient
    {
        private IAccessTokenProvider acccessTokenProvider = null;
        private ApiConfiguration configuration = null;
        private HttpClient httpClient = null;
        

        public ApiClient(IAccessTokenProvider auth = null, ApiConfiguration config = null)
        {
            acccessTokenProvider = auth ?? new AnonymousAccessTokenProvider();
            configuration = config ?? new ApiConfiguration();
            httpClient = new HttpClient(auth, config);
        }


        private CreativeWorkClient creativeWork;
        public CreativeWorkClient CreativeWork {
            get {
                if (creativeWork == null)
                    creativeWork = new CreativeWorkClient(httpClient);
                return creativeWork;
            }
        }
    }
}

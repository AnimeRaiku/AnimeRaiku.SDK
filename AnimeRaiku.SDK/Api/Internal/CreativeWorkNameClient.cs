using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public class CreativeWorkNameClient : BaseChildWriteClient<CreativeWork, CreativeWorkName>
    {
        internal CreativeWorkNameClient(HttpClient httpClient)
        {
            childEntity = "Name";
            this.httpClient = httpClient;
        }
    }
}

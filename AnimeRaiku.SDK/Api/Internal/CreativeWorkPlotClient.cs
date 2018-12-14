using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Api.Internal
{
    public class CreativeWorkPlotClient : BaseChildWriteClient<CreativeWork, Plot>
    {
        internal CreativeWorkPlotClient(HttpClient httpClient)
        {
            childEntity = "Plot";
            this.httpClient = httpClient;
        }
    }
}

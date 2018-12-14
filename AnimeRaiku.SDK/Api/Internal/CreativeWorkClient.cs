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
    public class CreativeWorkClient : BaseWriteClient<CreativeWork>
    {
        internal CreativeWorkClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        private CreativeWorkNameClient name;
        public CreativeWorkNameClient Name
        {
            get
            {
                if (name == null)
                    name = new CreativeWorkNameClient(httpClient);
                return name;
            }
        }

        private CreativeWorkPlotClient plot;
        public CreativeWorkPlotClient Plot
        {
            get
            {
                if (plot == null)
                    plot = new CreativeWorkPlotClient(httpClient);
                return plot;
            }
        }

    }
}

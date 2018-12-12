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
    public class CreativeWorkClient : BaseClient, IReadClient<CreativeWork>, IWriteClient<CreativeWork>
    {
        private HttpClient httpClient;

        internal CreativeWorkClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiMessage<CreativeWork>> CreateAsync(CreativeWork model)
        {
            return await httpClient.Create(model);
        }

        public Task<ApiMessage<CreativeWork>> UpdateAsync(string id, CreativeWork model)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiMessages<CreativeWork>> FindAsync(QueryExpression query = null)
        {
            return await httpClient.Find<CreativeWork>(query);
        }

        public async Task<ApiMessage<CreativeWork>> GetByIdAsync(string id)
        {
            return await httpClient.Get<CreativeWork>(id);
        }
    }
}

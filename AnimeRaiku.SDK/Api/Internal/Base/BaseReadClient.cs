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
    public abstract class BaseReadClient<T> : IReadClient<T> where T : BaseModel
    {
        internal HttpClient httpClient;

        public async Task<ApiMessages<T>> FindAsync(QueryExpression query = null)
        {
            return await httpClient.Find<T>(query);
        }

        public async Task<ApiMessage<T>> GetByIdAsync(string id)
        {
            return await httpClient.Get<T>(id);
        }
    }
}

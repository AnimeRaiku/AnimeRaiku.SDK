using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public abstract class BaseChildReadClient<T, U> : IChildReadClient<U> where T : BaseModel where U : BaseModel
    {
        protected String childEntity = null;

        internal HttpClient httpClient;
        public async Task<ApiMessages<U>> FindAsync(String id)
        {
            return await httpClient.FindChild<T, U>(id, childEntity);
        }

        public async Task<ApiMessage<U>> GetByIdAsync(String id, String childid)
        {
            return await httpClient.GetChild<T, U>(id, childid, childEntity);
        }
    }
}

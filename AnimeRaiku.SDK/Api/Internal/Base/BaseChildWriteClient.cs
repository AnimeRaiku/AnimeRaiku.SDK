using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public abstract class BaseChildWriteClient<T, U> : BaseChildReadClient<T, U>, IChildWriteClient<U> where T : BaseModel where U : BaseModel
    {
        public async Task<ApiMessage<U>> CreateAsync(string id, U model)
        {
            return await httpClient.CreateChild<T, U>(id, model, childEntity);
        }

        public async Task<ApiMessage<U>> UpdateAsync(string id, string childid, U model)
        {
            return await httpClient.UpdateChild<T, U>(id, childid, model, childEntity);
        }
    }
}

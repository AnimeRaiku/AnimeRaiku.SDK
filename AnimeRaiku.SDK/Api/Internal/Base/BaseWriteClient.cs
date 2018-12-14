using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public abstract class BaseWriteClient<T> : BaseReadClient<T>, IWriteClient<T> where T : BaseModel
    {

        public async Task<ApiMessage<T>> CreateAsync(T model)
        {
            return await httpClient.Create(model);
        }

        public async Task<ApiMessage<T>> UpdateAsync(string id, T model)
        {
            return await httpClient.Update(id, model);
        }
    }
}

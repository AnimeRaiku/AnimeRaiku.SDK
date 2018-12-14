using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public interface IWriteClient<T> : IClient where T : BaseModel
    {
        Task<ApiMessage<T>> CreateAsync(T model);

        Task<ApiMessage<T>> UpdateAsync(String id, T model);
    }
}

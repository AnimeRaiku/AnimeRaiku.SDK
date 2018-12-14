using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public interface IChildWriteClient<T> : IClient where T : BaseModel
    {
        Task<ApiMessage<T>> CreateAsync(String id, T model);

        Task<ApiMessage<T>> UpdateAsync(String id, String childid, T model);
    }
}

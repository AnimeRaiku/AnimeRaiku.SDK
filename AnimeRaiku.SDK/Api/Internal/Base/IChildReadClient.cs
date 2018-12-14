using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public interface IChildReadClient<T> : IClient where T : BaseModel
    {
        Task<ApiMessages<T>> FindAsync(String id);

        Task<ApiMessage<T>> GetByIdAsync(String id, String childid);
    }
}

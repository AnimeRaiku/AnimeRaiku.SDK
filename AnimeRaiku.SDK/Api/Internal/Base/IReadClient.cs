using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Api.Internal
{
    public interface IReadClient<T> : IClient where T : BaseModel
    {
        Task<ApiMessages<T>> FindAsync(QueryExpression query = null);

        Task<ApiMessage<T>> GetByIdAsync(String id);
    }
}

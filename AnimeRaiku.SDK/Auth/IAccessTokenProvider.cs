using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Auth
{
    public interface IAccessTokenProvider
    {
        Task<TokenInfo> GetAccessTokenAsync();
    }
}

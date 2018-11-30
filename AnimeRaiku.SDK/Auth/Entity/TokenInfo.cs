using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Auth.Entity
{
    public class TokenInfo
    {
        [JsonProperty(propertyName: "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(propertyName: "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(propertyName: "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(propertyName: "refresh_token")]
        public string RefreshToken { get; set; }
    }

}

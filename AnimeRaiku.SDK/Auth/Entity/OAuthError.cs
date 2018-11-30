using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Auth.Entity
{
    class OAuthError
    {
        [JsonProperty(propertyName: "error")]
        public string Error { get; set; }

        [JsonProperty(propertyName: "message")]
        public string Message { get; set; }
    }

}

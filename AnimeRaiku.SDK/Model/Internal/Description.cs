using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model.Internal
{
    public class Description
    {
        [JsonProperty(propertyName: "lang")]
        public string Lang { get; set; }

        [JsonProperty(propertyName: "content")]
        public string Content { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "id")]
        public Id Id { get; set; }
    }
}

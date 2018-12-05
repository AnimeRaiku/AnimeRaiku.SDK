using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class Label
    {
        [JsonProperty(propertyName: "lang")]
        public string Lang { get; set; }
        [JsonProperty(propertyName: "content")]
        public string Content { get; set; }
    }
}

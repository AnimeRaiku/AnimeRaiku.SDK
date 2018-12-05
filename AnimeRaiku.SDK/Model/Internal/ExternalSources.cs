using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class ExternalSources
    {
        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "_id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "url")]
        public string Url { get; set; }
    }
}

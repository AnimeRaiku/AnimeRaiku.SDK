using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model.Internal
{
    public class PersonCreativeWorks
    {
        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "role")]
        public string Role { get; set; }

        [JsonProperty(propertyName: "id")]
        public Id Id { get; set; }
    }
}

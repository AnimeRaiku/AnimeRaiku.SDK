using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model.Internal
{
    public class PolyReference : Reference
    {
        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }
    }
}

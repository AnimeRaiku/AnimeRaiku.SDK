using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model.Internal
{
    public class Reference
    {
        [JsonProperty(propertyName: "_id")]
        public string Id { get; set; }
    }
}

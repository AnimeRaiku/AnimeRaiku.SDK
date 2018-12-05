using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class DataProviderType : BaseModel
    {
        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "icon")]
        public string Icon { get; set; }
    }

}

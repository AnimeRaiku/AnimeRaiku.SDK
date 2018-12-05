using AnimeRaiku.SDK.Model.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class DataProvider : BaseModel
    {
        [JsonProperty(propertyName: "value")]
        public string Value { get; set; }
        [JsonProperty(propertyName: "label")]
        public Label[] Label { get; set; }
        [JsonProperty(propertyName: "type")]
        public Reference Type { get; set; }
    }

    

}

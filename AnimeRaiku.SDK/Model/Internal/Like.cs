using AnimeRaiku.SDK.Model.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class Like : BaseModel
    {
        [JsonProperty(propertyName: "object")]
        public PolyReference Object { get; set; }

        [JsonProperty(propertyName: "user")]
        public UserReference User { get; set; }

        [JsonProperty(propertyName: "folder")]
        public string Folder { get; set; }

        [JsonProperty(propertyName: "rating")]
        public int Rating { get; set; }
    }

    public class UserReference
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }
    }

}

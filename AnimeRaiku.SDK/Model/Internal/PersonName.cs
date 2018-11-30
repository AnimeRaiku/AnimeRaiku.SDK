using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model.Internal
{
    public class PersonName
    {
        [JsonProperty(propertyName: "lang")]
        public string Lang { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(propertyName: "last_name")]
        public string LastName { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }
                
        [JsonProperty(propertyName: "id")]
        public Id Id { get; set; }
    }
}

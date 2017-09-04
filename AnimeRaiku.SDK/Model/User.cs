using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{

    public class User : BaseModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "country_id")]
        public string CountryId { get; set; }

        [JsonProperty(propertyName: "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(propertyName: "last_visit")]
        public DateTime LastVisit { get; set; }
    }
}

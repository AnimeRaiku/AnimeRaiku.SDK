using AnimeRaiku.SDK.Model.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{

    public class Person : BaseModel
    {
        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "name")]
        public PersonName[] Name { get; set; }

        [JsonProperty(propertyName: "blood")]
        public string Blood { get; set; }

        [JsonProperty(propertyName: "external_sources")]
        public ExternalSources[] ExternalSources { get; set; }

        [JsonProperty(propertyName: "description")]
        public Description[] Description { get; set; }

        [JsonProperty(propertyName: "creative_works")]
        public PersonCreativeWorks[] CreativeWorks { get; set; }

        [JsonProperty(propertyName: "birth_date")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty(propertyName: "birth_place")]
        public string BirthPlace { get; set; }

        [JsonProperty(propertyName: "death_date")]
        public DateTime? DeathDate { get; set; }

        [JsonProperty(propertyName: "death_place")]
        public string DeathPlace { get; set; }

    }


    
    

}

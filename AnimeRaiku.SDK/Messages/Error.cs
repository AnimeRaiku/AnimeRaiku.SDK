using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Messages
{
    public class Error
    {
        [JsonProperty(propertyName: "status")]
        public int Status { get; set; }

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }

        [JsonProperty(propertyName: "detail")]
        public string Detail { get; set; }

        [JsonProperty(propertyName: "source")]
        public Source Source { get; set; }
    }

    public class Source
    {
        [JsonProperty(propertyName: "pointer")]
        public string Pointer { get; set; }

        [JsonProperty(propertyName: "parameter")]
        public string Parameter { get; set; }
    }

}

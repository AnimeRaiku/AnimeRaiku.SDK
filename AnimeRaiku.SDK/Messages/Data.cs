using AnimeRaiku.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Messages
{
    public class Data<T> where T : BaseModel
    {
        public Data() { }
        public Data(T model)
        {
            Attributes = model;
            Type = model.GetModelName();
        }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "attributes")]
        public T Attributes { get; set; }

        [JsonProperty(propertyName: "meta")]
        public Meta Meta { get; set; }

        [JsonProperty(propertyName: "links")]
        public Link Links { get; set; }
    }

    public class Link
    {
        [JsonProperty(propertyName: "self")]
        public String Self { get; set; }
    }

    public class Meta
    {
        [JsonProperty(propertyName: "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(propertyName: "created_by")]
        public int? CreatedBy { get; set; }

        [JsonProperty(propertyName: "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(propertyName: "updated_by")]
        public int? UpdatedBy { get; set; }
    }
}
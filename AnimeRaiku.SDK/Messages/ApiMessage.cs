using AnimeRaiku.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Messages
{


    public class ApiMessage<T> : BaseMessage where T : BaseModel
    {
        public ApiMessage() { }
        public ApiMessage(T model)
        {
            Data = new Data<T>(model);
        }

        [JsonProperty(propertyName: "data")]
        public Data<T> Data { get; set; }
    }

    public class ApiMessages<T> : BaseMessage where T : BaseModel
    {
        [JsonProperty(propertyName: "data")]
        public List<Data<T>> Data { get; set; }

        [JsonProperty(propertyName: "links")]
        public PaginationLinks Links { get; set; }

        [JsonProperty(propertyName: "meta")]
        public MessageMeta Meta { get; set; }
    }


    public abstract class BaseMessage
    {
        [JsonProperty(propertyName: "errors")]
        public Error[] Errors { get; set; }

        [JsonIgnore]
        public bool IsValid => Errors == null;
    }

    public class PaginationLinks
    {
        [JsonProperty(propertyName: "self")]
        public string Self { get; set; }
        [JsonProperty(propertyName: "first")]
        public string First { get; set; }
        [JsonProperty(propertyName: "next")]
        public string Next { get; set; }
        [JsonProperty(propertyName: "last")]
        public string Last { get; set; }
    }
    public class MessageMeta
    {
        [JsonProperty(propertyName: "pagination")]
        public PaginationMeta Pagination { get; set; }
    }

    public class PaginationMeta
    {
        [JsonProperty(propertyName: "total")]
        public int Total { get; set; }
        [JsonProperty(propertyName: "count")]
        public int Count { get; set; }
        [JsonProperty(propertyName: "per_page")]
        public int PerPage { get; set; }
        [JsonProperty(propertyName: "current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty(propertyName: "total_pages")]
        public int TotalPages { get; set; }
    }


}

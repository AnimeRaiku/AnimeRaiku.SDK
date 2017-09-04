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
    }


    public abstract class BaseMessage
    {
        [JsonProperty(propertyName: "errors")]
        public Error[] Errors { get; set; }

        [JsonIgnore]
        public bool IsValid => Errors == null;
    }

}

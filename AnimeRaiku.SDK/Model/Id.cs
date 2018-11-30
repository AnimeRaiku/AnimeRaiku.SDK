using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AnimeRaiku.SDK.Model
{
    [JsonConverter(typeof(IdJsonConverter))]
    public class Id
    {
        public Id(){
            id = "000000000000000000000000";
        }

        public static Id NewId()
        {
            return new Id(ObjectIdGenerator.GenerateNewId());
        }

        public Id(String id)
        {
            if (!Regex.IsMatch(id, "^[a-f0-9]{24}$"))
                throw new ArgumentOutOfRangeException("id");
            this.id = id;
        }

        private string id = null;
        public override string ToString()
        {
            return id;
        }
    }
}

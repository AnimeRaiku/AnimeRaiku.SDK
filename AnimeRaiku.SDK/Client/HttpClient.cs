using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Client
{
    internal class HttpClient
    {
        private IAccessTokenProvider acccessTokenProvider = null;
        private ApiConfiguration configuration = null;

        public HttpClient(IAccessTokenProvider auth = null, ApiConfiguration config = null)
        {
            acccessTokenProvider = auth ?? new AnonymousAccessTokenProvider();
            configuration = config ?? new ApiConfiguration();
        }

        public async Task<ApiMessage<T>> Create<T>(T model) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("POST", model.GetModelName(), new ApiMessage<T>(model));
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessage<U>> CreateChild<T,U>(String id, U model, String childentity = null) where T : BaseModel where U : BaseModel
        {
            var t = await MakeHttpRequest<U>("POST", typeof(T).Name + "/" + id + "/" + (childentity == null ? typeof(U).Name : childentity), new ApiMessage<U>(model));
            return Deserialize<ApiMessage<U>>(t);
        }

        public async Task<ApiMessage<T>> Update<T>(String id, T model) where T : BaseModel
        {
            var tmp = new ApiMessage<T>(model);
            tmp.Data.Id = id;

            var t = await MakeHttpRequest<T>("POST", model.GetModelName() + "/" +id,  tmp);
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessage<U>> UpdateChild<T,U>(String id, String childid, U model, String childentity = null) where T : BaseModel where U : BaseModel
        {
            var tmp = new ApiMessage<U>(model);
            tmp.Data.Id = id;

            var t = await MakeHttpRequest<U>("POST", typeof(T).Name + "/" + id + "/" + (childentity == null ? typeof(U).Name : childentity) + "/" + childid, tmp);
            return Deserialize<ApiMessage<U>>(t);
        }

        public async Task<ApiMessages<T>> Find<T>(QueryExpression query = null) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("GET", typeof(T).Name, null, ( query != null ? "?"+ query.ToString() : ""));
            return Deserialize<ApiMessages<T>>(t);
        }

        public async Task<ApiMessages<U>> FindChild<T,U>(String id, String childentity = null) where T : BaseModel where U : BaseModel
        {
            var t = await MakeHttpRequest<U>("GET", typeof(T).Name + "/" + id + "/" + (childentity == null ? typeof(U).Name : childentity));
            return Deserialize<ApiMessages<U>>(t);
        }

        public async Task<ApiMessage<T>> Get<T>(String id) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("GET", typeof(T).Name, null, "/" + id);
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessage<U>> GetChild<T,U>(String id, String childid, String childentity = null) where T : BaseModel where U : BaseModel
        {
            var t = await MakeHttpRequest<U>("GET", typeof(T).Name + "/" + id + "/" + (childentity == null ? typeof(U).Name : childentity) + "/" + childid);
            return Deserialize<ApiMessage<U>>(t);
        }

        private async Task<String> MakeHttpRequest<T>(String method, String entity, ApiMessage<T> apimessage = null, string extraurl = "") where T : BaseModel
        {
            string json = Serialize(apimessage);
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "AnimeRaiku C# SDK");

            var accessToken = await acccessTokenProvider.GetAccessTokenAsync();
            if (accessToken != null)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.AccessToken);

            var domain = configuration.BaseUrl;
            if (!domain.EndsWith("/"))
                domain += '/';

            Task<HttpResponseMessage> task = null;

            if(method == "GET")
                task = client.GetAsync(domain + entity + extraurl);

            if (method == "POST")
                task = client.PostAsync(domain + entity + extraurl, new StringContent(json, Encoding.UTF8, "application/json"));

            HttpResponseMessage msg = await task;

            HttpContent stream = (HttpContent)msg.Content;

            String data = await stream.ReadAsStringAsync();
            return data;
        }


        private String Serialize(Object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings() {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatString = "yyyy-MM-dd'T'HH:mm:ss'Z'"
            });
        }

        private T Deserialize<T>(String o)
        {
            return JsonConvert.DeserializeObject<T>(o, new JsonSerializerSettings() { });
        }
    }
}

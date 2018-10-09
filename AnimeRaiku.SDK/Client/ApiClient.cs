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
    public class ApiClient
    {
        private IAccessTokenProvider acccessTokenProvider = null;
        private Configuration configuration = null;

        public ApiClient(IAccessTokenProvider auth = null, Configuration config = null)
        {
            acccessTokenProvider = auth ?? new AnonymousAccessTokenProvider();
            configuration = config ?? new Configuration();
        }

        public async Task<ApiMessage<T>> Create<T>(T model) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("POST", model.GetModelName(), new ApiMessage<T>(model));
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessage<T>> Update<T>(String id, T model) where T : BaseModel
        {
            var tmp = new ApiMessage<T>(model);
            tmp.Data.Id = id;

            var t = await MakeHttpRequest<T>("POST", model.GetModelName(),  tmp);
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessages<T>> GetAll<T>(QueryExpression query = null) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("GET", typeof(T).Name, null, ( query != null ? "?"+ query.ToString() : ""));
            return Deserialize<ApiMessages<T>>(t);
        }

        public async Task<ApiMessage<T>> Get<T>(String id) where T : BaseModel
        {
            var t = await MakeHttpRequest<T>("GET", typeof(T).Name, null, "/" + id);
            return Deserialize<ApiMessage<T>>(t);
        }

        public async Task<ApiMessages<T>> Lookup<T>(String name, String type = null) where T : LookupModel
        {
            String query = "?q=" + name;
            if (type != null)
                query += "&type=" + type;

            var t = await MakeHttpRequest<T>("GET", typeof(T).Name, null, "/lookup" + query);
            return Deserialize<ApiMessages<T>>(t);
        }

        private async Task<String> MakeHttpRequest<T>(String method, String entity, ApiMessage<T> apimessage = null, string extraurl = "") where T : BaseModel
        {
            string json = Serialize(apimessage);
            var client = new HttpClient();
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
            return await stream.ReadAsStringAsync();
        }


        private String Serialize(Object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        private T Deserialize<T>(String o)
        {
            return JsonConvert.DeserializeObject<T>(o, new JsonSerializerSettings() { });
        }
    }
}

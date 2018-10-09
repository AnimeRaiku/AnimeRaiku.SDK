using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Auth
{
    public class PasswordProvider : IAccessTokenProvider
    {
        public String AuthUrl { get; set; } = "https://animeraiku.com";

        private String clientID;
        private String clientSecrect;
        private Func<NetworkCredential> GetCrendentials;
        public PasswordProvider(String clientID, String clientSecrect, Func<NetworkCredential> getCrendentials, String authUrl = null)
        {
            this.clientID = clientID;
            this.clientSecrect = clientSecrect;
            AuthUrl = authUrl;
            GetCrendentials = getCrendentials;
        }

        public async Task<TokenInfo> GetAccessTokenAsync()
        {
            var client = new HttpClient();
            //  client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(
            //   new MediaTypeWithQualityHeaderValue("application/json"));
            var credentials = GetCrendentials();
            client.DefaultRequestHeaders.Add("User-Agent", "AnimeRaiku C# SDK");

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", clientID),
                new KeyValuePair<string, string>("client_secret", clientSecrect),
                new KeyValuePair<string, string>("username", credentials.UserName),
                new KeyValuePair<string, string>("password", credentials.Password),
                new KeyValuePair<string, string>("scope", ""),
            });
            var response = await client.PostAsync(AuthUrl + "/oauth/token", formContent);
            
            var stringContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TokenInfo>(stringContent);
        }
    }
}

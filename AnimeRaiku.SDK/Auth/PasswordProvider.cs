using AnimeRaiku.SDK.Auth.Entity;
using AnimeRaiku.SDK.Auth.Exceptions;
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
        private Func<bool, NetworkCredential> GetCrendentials;
        private int retryCount = 3;
        public PasswordProvider(String clientID, String clientSecrect, Func<bool,NetworkCredential> getCrendentials, String authUrl = null)
        {
            this.clientID = clientID;
            this.clientSecrect = clientSecrect;
            AuthUrl = authUrl;
            GetCrendentials = getCrendentials;
        }

        public async Task<TokenInfo> GetAccessTokenAsync()
        {
            int currentRetry = 0;

            for (; ; )
            {
                try
                {
                    var credentials = GetCrendentials(currentRetry != 0);
                    if(credentials == null)
                    {
                        currentRetry = retryCount;
                        throw new UnauthorizedException();
                    }
                    HttpResponseMessage response = await MakeRequest(credentials);

                    var stringContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        var error = JsonConvert.DeserializeObject<OAuthError>(stringContent);
                        if (error.Error == "invalid_credentials")
                            throw new UnauthorizedException();
                        else if (error.Error == "invalid_client")
                            throw new InvalidClientException();
                        else
                            throw new Exception(stringContent);
                    }

                    return JsonConvert.DeserializeObject<TokenInfo>(stringContent);
                }
                catch (Exception ex)
                {
                    currentRetry++;
                    if (currentRetry > this.retryCount || !IsTransient(ex))
                        throw;
                }
            }
        }

        private bool IsTransient(Exception ex)
        {
            if (ex is UnauthorizedException)
                return true;
            return false;
        }

        private async Task<HttpResponseMessage> MakeRequest(NetworkCredential credentials)
        {
            var client = new HttpClient();
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
            return response;
        }
    }
}

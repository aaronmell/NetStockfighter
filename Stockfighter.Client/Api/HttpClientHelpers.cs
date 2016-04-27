using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stockfighter.Client.Api
{
     
    internal class HttpClientHelpers
    {
        private HttpClient HttpClient;

        internal HttpClientHelpers(Uri baseAddress, string apiKey)
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpClient.DefaultRequestHeaders.Add("X-Starfighter-Authorization", apiKey);
        }

        internal async Task<string> PostAsync(string uri, object data)
        {
            var postDate = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(data)).ConfigureAwait(false);

            var result = await HttpClient.PostAsync(uri, new StringContent(postDate, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        internal async Task<string> GetAsync(string uri)
        {
            //Doing this instead of ReadString, because a bad value returns 404 instead of 200, and we can't get the error message otherwise.
            var result = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        internal async Task<string> DeleteAsync(string uri)
        {
            var result = await HttpClient.DeleteAsync(uri).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

    }
}

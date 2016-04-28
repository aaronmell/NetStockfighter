using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    public class QuoteFeedResponse
    {
        /// <summary>
        /// Indicated is a request is successful
        /// </summary>
        [JsonProperty("ok")]
        public bool RequestSuccessful { get; set; }

        /// <summary>
        /// If the request is not successful, the error message can tell you what went wrong
        /// </summary>
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// <see cref="Quote"/>
        /// </summary>
        public Quote Quote { get; set; }
    }
}

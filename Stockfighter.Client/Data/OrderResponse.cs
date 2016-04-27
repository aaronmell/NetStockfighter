using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The response returned from placing an order
    /// </summary>
    public class OrderResponse : Order
    {
        /// <summary>
        /// Was the request successful
        /// </summary>
        [JsonProperty("ok")]
        public bool RequestSuccessful { get; set; }

        /// <summary>
        /// An error message returned when Request successful is false.
        /// </summary>
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The id of the venue
        /// </summary>
        public string Venue { get; set; }
    }
}

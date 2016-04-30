using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The request used with submitting an order
    /// </summary>
    public class SubmitOrderRequest
    {
        /// <summary>
        /// The account Id
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// The venue id
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// The stock symbol
        /// </summary>
        public string Stock { get; set; }

        /// <summary>
        /// The prce
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The quantity
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity { get; set; }

        /// <summary>
        /// <see cref="OrderType"/>
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        /// <see cref="Direction"/>
        /// </summary>
        public Direction Direction {get; set;}
    }
}

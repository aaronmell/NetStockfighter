using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// An offer to purchase stock
    /// </summary>
    public class Bid
    {
        /// <summary>
        /// The price of the bid
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The quantity of the bid
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity { get; set; }

        /// <summary>
        /// Is the bid a buy or sell
        /// </summary>
        public bool IsBuy { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// a transaction for a stock
    /// </summary>
    public class Fills
    {
        /// <summary>
        /// The price paid
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The quantity purchased
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity { get; set; }

        /// <summary>
        /// The time the fill was made
        /// </summary>
        [JsonProperty("ts")]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// <see cref="Direction"/>
        /// </summary>
        public Direction Direction { get; set; }
    }
}

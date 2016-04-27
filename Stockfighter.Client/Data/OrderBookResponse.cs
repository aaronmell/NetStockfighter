using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The list of orders for a venu uses to record the interest of buyers and sellers of a particular financial instrument
    /// </summary>
    public class OrderBookResponse : BaseStockResponse
    {     
        /// <summary>
        /// A list of <see cref="Bid"/> offers to buy stocks
        /// </summary>
        public List<Bid> Bids { get; set; }

        /// <summary>
        /// A lisst of <see cref="Bid"/> offers to sell stocks
        /// </summary>
        public List<Bid> Asks { get; set; }

        /// <summary>
        /// The timestamp the Orderbook was recieved.
        /// </summary>
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
    }
}

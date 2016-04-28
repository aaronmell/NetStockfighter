using Newtonsoft.Json;
using System;

namespace Stockfighter.Client.Data
{
    public class Quote
    {
        // <summary>
        /// The best bid price for the stock
        /// </summary>
        [JsonProperty("bid")]
        public int BidPrice { get; set; }

        /// <summary>
        /// The best ask price for the stock
        /// </summary>
        [JsonProperty("ask")]
        public int AskPrice { get; set; }

        /// <summary>
        /// The aggregate size of all orders at the best bid price
        /// </summary>
        public int BidSize { get; set; }

        /// <summary>
        /// The aggregate size of all orders at the best ask price
        /// </summary>
        public int AskSize { get; set; }

        /// <summary>
        /// The aggregate size of all bids
        /// </summary>
        public int BidDepth { get; set; }

        /// <summary>
        /// The aggregate size of all asks
        /// </summary>
        public int AskDepth { get; set; }

        /// <summary>
        /// The price of the last trade
        /// </summary>
        [JsonProperty("last")]
        public int LastPrice { get; set; }

        /// <summary>
        /// the quantity of the last trade
        /// </summary>
        public int LastSize { get; set; }

        /// <summary>
        /// The timestamp of the last trade
        /// </summary>
        [JsonProperty("lastTrade")]
        public DateTime LastTradeTime { get; set; }

        /// <summary>
        /// The timestamp the quote was last updated at
        /// </summary>
        [JsonProperty("quoteTime")]
        public DateTime LastQuoteUpdateTime { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// A request to purchase or sell a quantity of stock
    /// </summary>
    public class Order
    {
        /// <summary>
        /// <see cref="Direction"/>
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// The original quantity placed
        /// </summary>
        [JsonProperty("originalQty")]
        public int OriginalQuantity { get; set; }

        /// <summary>
        /// The quantity left unfilled
        /// </summary>
        [JsonProperty("qty")]
        public int OutstandingQuantity { get; set; }

        /// <summary>
        /// The prices of the order, this may not match the price paid on the fills!
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// <see cref="OrderType"/>
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        /// A unique id of the order. This id is only unique on the venue it was placed on. 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The account that placed the order
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// The time when the order was placed
        /// </summary>
        [JsonProperty("ts")]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// The total number of shares filled
        /// </summary>
        public int TotalFilled { get; set; }

        /// <summary>
        /// Is the order still outstanding
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// A lists of <see cref="Fills"/>
        /// </summary>
        public List<Fills> Fills { get; set; }
    }
}

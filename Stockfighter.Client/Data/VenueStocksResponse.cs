using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The response returned when requesting stocks from a venue
    /// </summary>
    public class VenueStocksResponse : BaseResponse
    {
        /// <summary>
        /// <see cref="StockSymbol"/>
        /// </summary>
        [JsonProperty("symbols")]
        public List<StockSymbol> StockSymbols { get; set; } 
    }
}

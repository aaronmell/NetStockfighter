﻿using Newtonsoft.Json;


namespace Stockfighter.Client.Data
{
    public class StockQuoteResponse : Quote
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
        /// The id of a venue 
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// The id of the stock symbol
        /// </summary>
        public string Symbol { get; set; }
    }
}

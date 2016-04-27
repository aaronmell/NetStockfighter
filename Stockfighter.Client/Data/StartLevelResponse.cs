using System.Collections.Generic;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The response returned when starting a level
    /// </summary>
    public class StartLevelResponse : BaseResponse
    {
        /// <summary>
        /// The id of the account trading will occur with
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// The id of the instance running
        /// </summary>
        public int InstanceId { get; set; }
       
        /// <summary>
        /// <see cref="LevelInstructions"/>
        /// </summary>
        public LevelInstructions Instructions { get; set; }

        /// <summary>
        /// The number of seconds each trading day lasts
        /// </summary>
        public int SecondsPerTradingDay { get; set; }

        /// <summary>
        /// A list of stocks
        /// </summary>
        public List<string> Tickers { get; set; }

        /// <summary>
        /// A list of venues
        /// </summary>
        public List<string> Venues { get; set; }

        /// <summary>
        /// <see cref="Balances"/>
        /// </summary>
        public Balances Balances { get; set; }
    }
}
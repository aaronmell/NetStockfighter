using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// Details of a given instance of a level
    /// </summary>
    public class InstanceDetails
    {
        /// <summary>
        /// The number of days remaining on this instances
        /// </summary>
        [JsonProperty("endOfTheWorldDay")]
        public string DaysRemaining { get; set; }

        /// <summary>
        /// The current day on this instance
        /// </summary>
        [JsonProperty("tradingDay")]
        public string CurrentDay { get; set; }
    }
}
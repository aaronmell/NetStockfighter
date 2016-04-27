
namespace Stockfighter.Client.Data
{
    /// <summary>
    /// Base response for responses that return both a venu and symbol.
    /// </summary>
    public class BaseStockResponse : BaseResponse
    {
        /// <summary>
        /// The id of a venue 
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// The id of symbol
        /// </summary>
        public string Symbol { get; set; }
    }
}

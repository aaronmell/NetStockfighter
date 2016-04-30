using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    public class QuoteFeedResponse : BaseResponse
    {       
        /// <summary>
        /// <see cref="Quote"/>
        /// </summary>
        public Quote Quote { get; set; }
    }
}

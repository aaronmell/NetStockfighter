using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// An enum that represents buy/sell
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Direction
    {
        Buy,

        Sell
    }
}

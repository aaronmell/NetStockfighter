using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// An enum that describes the type of order being made
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        /// <summary>
        /// An order to buy or sell at a given price or better.
        /// </summary>
        Limit,

        /// <summary>
        /// An order to buy sell at the prevailing price.
        /// </summary>
        Market,

        /// <summary>
        /// An order where all shares must be filled immediately or the order is cancelled
        /// </summary>
        [EnumMember(Value = "fill-or-kill")]
        FillOrKill,

        /// <summary>
        /// Like a fill or kill, except it accepts partial execution. Any shares not filled immediate would be cancelled.
        /// </summary>
        [EnumMember(Value = "immediate-or-cancel")]
        ImmediateOrCancel
    }
}

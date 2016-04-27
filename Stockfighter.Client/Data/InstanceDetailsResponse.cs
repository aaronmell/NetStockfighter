using Newtonsoft.Json;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// A response returns that includes the details of a given instance
    /// </summary>
    public class InstanceDetailsResponse : BaseResponse
    {
        /// <summary>
        /// <see cref="InstanceDetails"/>
        /// </summary>
        [JsonProperty("details")]
        public InstanceDetails InstanceDetails { get; set; }

        /// <summary>
        /// Is the instance still running?
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// The unique id of the instance
        /// </summary>
        [JsonProperty("id")]
        public int InstanceId { get; set; }

        /// <summary>
        /// The current state of the instance
        /// </summary>
        public string State { get; set; }

    }
}
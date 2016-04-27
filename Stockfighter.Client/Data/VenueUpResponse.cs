
namespace Stockfighter.Client.Data
{
    /// <summary>
    /// Responsed returned when checking if a venue is up
    /// </summary>
    public class VenueUpResponse : BaseResponse
    {
        /// <summary>
        /// The name of the venue;
        /// </summary>
        public string Venue { get; set; }
    }
}

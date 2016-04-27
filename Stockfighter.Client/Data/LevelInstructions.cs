namespace Stockfighter.Client.Data
{
    /// <summary>
    /// The instructions for the level
    /// </summary>
    public class LevelInstructions
    {
        /// <summary>
        /// A description of the level and the goals for a level
        /// </summary>
        public string Instructions { get; set; }
        /// <summary>
        /// Describes the types of orders that can be placed
        /// </summary>
        public string OrderTypes { get; set; }
    }
}
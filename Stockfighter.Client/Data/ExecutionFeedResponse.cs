using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockfighter.Client.Data
{
    /// <summary>
    /// Contains data returned by the exection feed
    /// </summary>
    public class ExecutionFeedResponse : BaseStockResponse
    {  
        /// <summary>
        /// The id of the account
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// <see cref="Order"/>
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// The id of the order on the book
        /// </summary>
        public int StandingId { get; set; }

        /// <summary>
        /// The id of the incoming order
        /// </summary>
        public int IncomingId { get; set; }

        /// <summary>
        /// The price of the order
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// the number of orders filled
        /// </summary>
        public int filled { get; set; }

        /// <summary>
        /// The timestamp the order was filled at
        /// </summary>
        public DateTime FilledAt { get; set; }

        /// <summary>
        /// Was the sanding order on the book complete
        /// </summary>
        public bool StandingComplete { get; set; }

        /// <summary>
        /// Was the incoming order complete (as of this execution)
        /// </summary>
        public bool IncomingComplete { get; set; }
    }
}

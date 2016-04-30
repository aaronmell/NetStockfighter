using Stockfighter.Client.Data;
using System;


namespace Stockfighter.Client.Api
{
    public class ExecutionFeed : BaseFeed<ExecutionFeedResponse>, IExecutionFeed, IDisposable
    {
        public ExecutionFeed(string account, string venue, bool reconnectOnClose)
            : base(account, venue, "executions", reconnectOnClose)
        {

        }

        public ExecutionFeed(string account, string venue, string stock, bool reconnectOnClose)
           : base(account, venue, stock, "executions", reconnectOnClose)
        {

        }
    }
}

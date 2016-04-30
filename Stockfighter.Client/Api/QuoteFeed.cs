using Newtonsoft.Json;
using Stockfighter.Client.Data;
using System;

using WebSocket4Net;

namespace Stockfighter.Client.Api
{
    public class QuotesFeed : BaseFeed<QuoteFeedResponse>, IQuoteFeed, IDisposable
    {
        public QuotesFeed(string account, string venue, bool reconnectOnClose)
            : base(account, venue, "tickertape", reconnectOnClose)
        {

        }

        public QuotesFeed(string account, string venue, string stock, bool reconnectOnClose)
           : base(account, venue, stock, "tickertape", reconnectOnClose)
        {

        }
    }
}

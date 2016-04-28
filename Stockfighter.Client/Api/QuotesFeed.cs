using Newtonsoft.Json;
using Stockfighter.Client.Data;
using System;

using WebSocket4Net;

namespace Stockfighter.Client.Api
{
    public class QuotesFeed : IQuotesFeed, IDisposable
    {
        private WebSocket _quotesFeedSocket;
        private bool _reconnectOnClose;
        private bool _isOpen;

        public QuotesFeed(string account, string venue, bool reconnectOnClose)
        {
            _quotesFeedSocket = new WebSocket(string.Format("wss://api.stockfighter.io/ob/api/ws/{0}/venues/{1}/tickertape", account, venue));
            _reconnectOnClose = reconnectOnClose;
        }

        public QuotesFeed(string account, string venue, string stock, bool reconnectOnClose)
        {
            _quotesFeedSocket = new WebSocket(string.Format("wss://api.stockfighter.io/ob/api/ws/{0}/venues/{1}/tickertape/stocks/{2}", account, venue, stock));
            _reconnectOnClose = reconnectOnClose;
        }

        public EventHandler<QuoteFeedResponse> QuoteReceived;
        public EventHandler<string> ErrorOccured;

        public void Start()
        {
            if (_isOpen)
                return;

            _quotesFeedSocket.MessageReceived += (sender, e) =>
            {
                QuoteFeedResponse quote = null;

                try
                {
                    quote = JsonConvert.DeserializeObject<QuoteFeedResponse>(e.Message);
                }
                catch (Exception ex)
                {
                    ErrorOccured(this, ex.Message);
                }

                if (quote != null && quote.RequestSuccessful && quote.Quote != null && QuoteReceived != null)
                {
                    QuoteReceived(this, quote);
                }
            };

            _quotesFeedSocket.Closed += (sender, e) =>
            {
                if (_quotesFeedSocket != null && _reconnectOnClose)
                {
                    _quotesFeedSocket.Open();
                    _isOpen = true;
                    return;
                }                
            };

            _quotesFeedSocket.Open();
            _isOpen = true;


        }         

        public void Dispose()
        {
           if (!_isOpen)
                return;

            _quotesFeedSocket.Close();

            _isOpen = false;
            _quotesFeedSocket.Dispose();
        }
    }
}

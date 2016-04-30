using Newtonsoft.Json;
using Stockfighter.Client.Data;
using System;
using WebSocket4Net;

namespace Stockfighter.Client.Api
{
    public class BaseFeed<T> where T : BaseResponse
    {
        private WebSocket _feedSocket;
        private bool _reconnectOnClose;
        private bool _isOpen;

        public BaseFeed(string account, string venue, string feedName, bool reconnectOnClose)
        {
            _feedSocket = new WebSocket(string.Format("wss://api.stockfighter.io/ob/api/ws/{0}/venues/{1}/{2}", account, venue, feedName));
            _reconnectOnClose = reconnectOnClose;
        }

        public BaseFeed(string account, string venue, string stock, string feedName, bool reconnectOnClose)
        {
            _feedSocket = new WebSocket(string.Format("wss://api.stockfighter.io/ob/api/ws/{0}/venues/{1}/{2}/stocks/{3}", account, venue, feedName, stock));
            _reconnectOnClose = reconnectOnClose;
        }

        public EventHandler<T> messageRecieved;
        public EventHandler<string> ErrorOccured;

        public void Start()
        {
            if (_isOpen)
                return;

            _feedSocket.MessageReceived += (sender, e) =>
            {
                T message = default(T);

                try
                {
                    message = JsonConvert.DeserializeObject<T>(e.Message);

                    if (message.RequestSuccessful)
                    {
                        messageRecieved(this, message);
                    }
                    else
                    {
                        ErrorOccured(this, message.ErrorMessage);

                    }

                }
                catch (Exception ex)
                {
                    ErrorOccured(this, ex.Message);
                }
            };

            _feedSocket.Closed += (sender, e) =>
            {
                if (_feedSocket != null && _reconnectOnClose)
                {
                    _feedSocket.Open();
                    _isOpen = true;
                    return;
                }
            };

            _feedSocket.Open();
            _isOpen = true;
        }

        public void Dispose()
        {
            if (!_isOpen)
                return;

            _feedSocket.Close();

            _isOpen = false;
            _feedSocket.Dispose();
        }
    }
}

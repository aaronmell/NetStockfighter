using System;
using System.Threading.Tasks;
using Stockfighter.Client.Data;
using Newtonsoft.Json;

namespace Stockfighter.Client.Api
{
    /// <summary>
    /// Concrete implementation of the <see cref="IClient"/> interface
    /// </summary>
    public class Client : IClient
    {
        private static HttpClientHelpers HttpClientHelpers;

        /// <summary>
        /// Creates a new instance of the <see cref="Client"/>
        /// </summary>
        /// <param name="apiKey">The api key used to authenticate with stockfighter</param>
        public Client(string apiKey)
        {
            HttpClientHelpers = new HttpClientHelpers(new Uri("https://api.stockfighter.io/ob/api/"), apiKey);
        }

        /// <summary>
        /// Checks the API to see if it is up and responding to requests
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/heartbeat"/>
        /// <returns><see cref="BaseResponse"/></returns>
        public async Task<BaseResponse> HeartBeatAsync()
        {
            var result = await HttpClientHelpers.GetAsync("heartbeat").ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<BaseResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a given venue is up
        /// </summary>
        ///<seealso cref="https://starfighter.readme.io/docs/venue-healthcheck"/>
        /// <param name="venue">The id of the venue</param>
        /// <returns><see cref="VenueUpResponse"/></returns>
        public async Task<VenueUpResponse> IsVenueUpAsync(string venue)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("https://api.stockfighter.io/ob/api/venues/{0}/heartbeat", venue)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VenueUpResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the stocks being traded on a given venue
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/list-stocks-on-venue"/>
        /// <param name="venue">The id of the venue</param>
        /// <returns><see cref="VenueStocksResponse"/></returns>
        public async Task<VenueStocksResponse> GetStocksAsync(string venue)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("https://api.stockfighter.io/ob/api/venues/{0}/stocks", venue)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VenueStocksResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the order book for a given stock on a given venue
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/get-orderbook-for-stock"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="stock">The id of the stock</param>
        /// <returns><see cref="OrderBookResponse"/></returns>
        public async Task<OrderBookResponse> GetOrderBookAsync(string venue, string stock)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("https://api.stockfighter.io/ob/api/venues/{0}/stocks/{1}", venue, stock)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<OrderBookResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the quote for a given stock on a given venue
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/a-quote-for-a-stock"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="stock">The id of the stock</param>
        /// <returns><see cref="StockQuoteResponse"/></returns>
        public async Task<StockQuoteResponse> GetQuoteAsync(string venue, string stock)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("venues/{0}/stocks/{1}/quote", venue, stock)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StockQuoteResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details of an order
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/status-for-an-existing-order"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="stock">The id of the stock</param>
        /// <param name="id"></param>
        /// <returns><see cref="OrderResponse"/></returns>
        public async Task<OrderResponse> GetOrderAsync(string venue, string stock, int id)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("venues/{0}/stocks/{1}/orders/{2}", venue, stock, id)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<OrderResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all of the orders for a given venue and account
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/status-for-all-orders"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="account">The id of the account</param>
        /// <returns><see cref="AllOrdersStatusResponse"/></returns>
        public async Task<AllOrdersStatusResponse> GetAllOrdersAsync(string venue, string account)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("venues/{0}/accounts/{1}/orders", venue, account)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<AllOrdersStatusResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all of the orders for a given venue, account and stock
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/status-for-all-orders-in-a-stock"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="account">The id of the account</param>
        /// <param name="stock">The id of the stock</param>
        /// <returns><see cref="AllOrdersStatusResponse"/></returns>
        public async Task<AllOrdersStatusResponse> GetAllOrdersAsync(string venue, string account, string stock)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("venues/{0}/accounts/{1}/stocks/{2}/orders", venue, account, stock)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<AllOrdersStatusResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Submits an order
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/place-new-order"/>
        /// <param name="submitOrderRequest"><see cref="SubmitOrderRequest"/></param>
        /// <returns><see cref="OrderResponse"/></returns>
        public async Task<OrderResponse> SubmitOrder(SubmitOrderRequest submitOrderRequest)
        {
            var result = await HttpClientHelpers.PostAsync(string.Format("venues/{0}/stocks/{1}/orders", submitOrderRequest.Venue, submitOrderRequest.Stock), submitOrderRequest).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<OrderResponse>(result)).ConfigureAwait(false);

        }

        /// <summary>
        /// Cancels an order
        /// </summary>
        /// <seealso cref="https://starfighter.readme.io/docs/cancel-an-order"/>
        /// <param name="venue">The id of the venue</param>
        /// <param name="stock">The id of the stock</param>
        /// <param name="orderId">The id of the order</param>
        /// <returns><see cref="OrderResponse"/><see cref="OrderResponse"/></returns>
        public async Task<OrderResponse> CancelOrder(string venue, string stock, int orderId)
        {
            var result = await HttpClientHelpers.DeleteAsync(string.Format("venues/{0}/stocks/{1}/orders/{2}", venue, stock, orderId)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<OrderResponse>(result)).ConfigureAwait(false);
        }        
    }   
}

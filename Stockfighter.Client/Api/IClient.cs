using Stockfighter.Client.Data;
using System.Threading.Tasks;

namespace Stockfighter.Client.Api
{
    /// <summary>
    /// Describes the methods used to interact with an instance of the game.
    /// </summary>
    public interface IClient
    {
        Task<BaseResponse> HeartBeatAsync();

        Task<VenueUpResponse> IsVenueUpAsync(string venue);

        Task<VenueStocksResponse> GetStocksAsync(string venue);

        Task<OrderBookResponse> GetOrderBookAsync(string venue, string stock);

        Task<StockQuoteResponse> GetQuoteAsync(string venue, string stock);

        Task<OrderResponse> GetOrderAsync(string venue, string stock, int id);

        Task<AllOrdersStatusResponse> GetAllOrdersAsync(string venue, string account);

        Task<AllOrdersStatusResponse> GetAllOrdersAsync(string venue, string account, string stock);

        Task<OrderResponse> SubmitOrder(SubmitOrderRequest submitOrderRequest);

        Task<OrderResponse> CancelOrder(string venue, string stock, int orderId);
    }
}

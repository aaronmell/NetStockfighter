using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Configuration;
using Stockfighter.Client.Api;
using Stockfighter.Client.Data;

namespace Stockfighter.Api.IntigrationTests
{
    [TestClass]
    public class ClientTests
    {
        public ClientTests()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Unable to Instantiate StockfighterApi. ApiKey is missing from application settings");
            }

            stockfighterApi = new Client.Api.Client(apiKey);
        }

        private IClient stockfighterApi;
        private const string GoodVenue = "TESTEX";
        private const string BadVenue = "BADVENUE";
        private const string GoodStock = "FOOBAR";
        private const string BadStock = "BADSTOCK";
        private const string BadAccount = "BADACCOUNT";

        #region IsApiUp Tests
        [TestMethod]
        public void Client_IsApiUpAsync_Returns_Response()
        {
            var result = stockfighterApi.HeartBeatAsync();

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsTrue(result.Result.RequestSuccessful);
        }
        #endregion

        #region IsVenueUp Tests
        [TestMethod]
        public void Client_IsVenueUpAsync_Returns_Request_Successful_On_Valid_Venue()
        {
            var result = stockfighterApi.IsVenueUpAsync(GoodVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsTrue(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_IsVenueUpAsync_Returns_Request_Not_Successful_On_Invalid_Venue()
        {
            var result = stockfighterApi.IsVenueUpAsync(BadVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_IsVenueUpAsync_Returns_Error_On_Invalid_Venue()
        {
            var result = stockfighterApi.IsVenueUpAsync(BadVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }
        #endregion

        #region GetStocksAsync Tests
        [TestMethod]
        public void Client_GetStocksAsync_Returns_Request_Not_Successful_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetStocksAsync(BadVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetStocksAsync_Returns_Error_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetStocksAsync(BadVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetStocksAsync_Returns_Request_Successful_On_Valid_Venue()
        {
            var result = stockfighterApi.GetStocksAsync(GoodVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsTrue(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetStocksAsync_Returns_Valid_Data_On_Valid_Venue_And_Stock()
        {
            var result = stockfighterApi.GetStocksAsync(GoodVenue);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.AreEqual(1, result.Result.StockSymbols.Count);
            Assert.AreEqual(GoodStock, result.Result.StockSymbols.First().Symbol);
        }
        #endregion

        #region GetOrderBookAsync Tests
        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Request_Not_Successful_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetOrderBookAsync(BadVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Request_Not_Successful_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetOrderBookAsync(GoodVenue, BadStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Error_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetOrderBookAsync(BadVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Error_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetOrderBookAsync(GoodVenue, BadStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Request_Successful_On_Valid_Venue()
        {
            var result = stockfighterApi.GetOrderBookAsync(GoodVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsTrue(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetOrderBookAsync_Returns_Valid_Data_On_Valid_Venue()
        {
            var result = stockfighterApi.GetOrderBookAsync(GoodVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.AreEqual(GoodVenue, result.Result.Venue);
            Assert.AreEqual(GoodStock, result.Result.Symbol);            

            Assert.IsTrue(result.Result.Timestamp.Ticks > 0);
        }
        #endregion

        #region
        [TestMethod]
        public void Client_GetQuoteAsync_Returns_Request_Not_Successful_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetQuoteAsync(BadVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

         [TestMethod]
        public void Client_GetQuoteAsync_Returns_Request_Not_Successful_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetQuoteAsync(GoodVenue, BadStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetQuoteAsync_Returns_Error_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetQuoteAsync(BadVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetQuoteAsync_Returns_Error_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetQuoteAsync(GoodVenue, BadStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetQuoteAsync_Returns_Request_Successful_On_Valid_Venue()
        {
            var result = stockfighterApi.GetQuoteAsync(GoodVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsTrue(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetQuoteAsync_Returns_Valid_Data_On_Valid_Venue_And_Stock()
        {
            var result = stockfighterApi.GetQuoteAsync(GoodVenue, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.AreEqual(GoodStock, result.Result.Symbol);
            Assert.AreEqual(GoodVenue, result.Result.Venue);
           
            Assert.IsTrue(result.Result.LastQuoteUpdateTime.Ticks > 0);
            Assert.IsTrue(result.Result.LastTradeTime.Ticks > 0);
        }
        #endregion

        #region GetOrderAsync Tests
        [TestMethod]
        public void Client_GetOrderAsync_Returns_Request_Not_Successful_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetOrderAsync(BadVenue, GoodStock, 0);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetOrderAsync_Returns_Request_Not_Successful_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetOrderAsync(GoodVenue, BadStock, 0);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetOrderAsync_Returns_Error_On_Invalid_Venue()
        {
            var result = stockfighterApi.GetOrderAsync(BadVenue, GoodStock, 0);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }

        [TestMethod]
        public void Client_GetOrderAsync_Returns_Error_On_Invalid_Stock()
        {
            var result = stockfighterApi.GetOrderAsync(GoodVenue, BadStock, 0);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }
        #endregion

        #region Tests
        [TestMethod]
        public void Client_GetAllOrdersAsync_Returns_Request_Not_Successful_On_Invalid_Account()
        {
            var result = stockfighterApi.GetAllOrdersAsync(GoodVenue, BadAccount);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetAllOrdersAsync_Returns_Error_On_Invalid_Account()
        {
            var result = stockfighterApi.GetAllOrdersAsync(GoodVenue, BadAccount);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }
        

        [TestMethod]
        public void Client_GetAllOrdersAsync_Returns_Request_Not_Successful_On_Invalid_Account2()
        {
            var result = stockfighterApi.GetAllOrdersAsync(GoodVenue, BadAccount, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsFalse(result.Result.RequestSuccessful);
        }

        [TestMethod]
        public void Client_GetAllOrdersAsync_Returns_Error_On_Invalid_Account2()
        {
            var result = stockfighterApi.GetAllOrdersAsync(GoodStock, BadAccount, GoodStock);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);

            Assert.IsNotNull(result.Result.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result.Result.ErrorMessage);
        }
        #endregion

        #region LiveTests

        //[TestMethod]
        public void Client_GetAllOrdersAsync_Returns_Data()
        {
            var result = stockfighterApi.GetAllOrdersAsync("QICDEX", "PAP92732141", "IVUX");

            result.Wait();

            Assert.IsTrue(result.IsCompleted);
        }

        //[TestMethod]
        public void Client_SubmitOrdersAsync_Returns_Data()
        {
            var result = stockfighterApi.SubmitOrder(new SubmitOrderRequest
            {
                Venue = "QICDEX",
                Stock = "IVUX",
                Account = "PAP92732141",
                Direction = Direction.Buy,
                OrderType = OrderType.Market,
                Quantity = 100,
                Price = 52
            });

            result.Wait();

            Assert.IsTrue(result.IsCompleted);
        }

        //[TestMethod]
        public void Client_DeleteOrdersAsync_Returns_Data()
        {
            var result = stockfighterApi.CancelOrder("QICDEX", "IVUX", 195);

            result.Wait();

            Assert.IsTrue(result.IsCompleted);
        }
        #endregion  
    }
}

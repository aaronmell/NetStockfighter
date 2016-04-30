using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter.Client.Api;
using Stockfighter.Client.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace Stockfigher.Api.IntigrationTests
{
    [TestClass]
    public class QuoteFeedTests
    {
        private IGameMasterClient _gameMasterApi;
        private IClient _client;
        private StartLevelResponse _startLevelResponse;

        public QuoteFeedTests()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Unable to Instantiate StockfighterApi. ApiKey is missing from application settings");
            }

            _gameMasterApi = new GameMasterClient(apiKey);
            _client = new Client(apiKey);
        }     
        
        [TestInitialize]
        public void Run_Before_Each_Test()
        {
            var start = _gameMasterApi.StartLevelAsync("first_steps");

            start.Wait();

            Assert.IsTrue(start.Result.RequestSuccessful);

            _startLevelResponse = start.Result;
        }
        
        [TestCleanup]
        public void Run_After_Each_Test()
        {
            var stop = _gameMasterApi.StopLevelAsync(_startLevelResponse.InstanceId);

            stop.Wait();

            //To prevent getting locked out due to start/stop being too fast
            Thread.Sleep(15000);
        }   

        [TestMethod]
        public void QuoteFeed_Returns_Quotes()
        {
            var quoteFeed = new QuotesFeed(_startLevelResponse.Account,_startLevelResponse.Venues.First(), false);
            var quotes = new List<QuoteFeedResponse>();

            quoteFeed.messageRecieved += (sender, e) =>
            {
                quotes.Add(e);
            };

            quoteFeed.Start();

            while (quotes.Count == 0)
            {
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void QuoteFeed_Returns_Quotes_From_Stock()
        {
            var stocks = _client.GetStocksAsync(_startLevelResponse.Venues.First());
            stocks.Wait();

            if (stocks.IsFaulted || !stocks.Result.RequestSuccessful || !stocks.Result.StockSymbols.Any())
            {
                Assert.Fail("Unable to get stocks from the game instance");
            }

            var quoteFeed = new QuotesFeed(_startLevelResponse.Account, _startLevelResponse.Venues.First(), stocks.Result.StockSymbols.First().Symbol, false);
            var quotes = new List<QuoteFeedResponse>();

            quoteFeed.messageRecieved += (sender, e) =>
            {
                quotes.Add(e);
            };

            quoteFeed.Start();

            while (quotes.Count == 0)
            {
                Thread.Sleep(100);
            }
        }
    }
}

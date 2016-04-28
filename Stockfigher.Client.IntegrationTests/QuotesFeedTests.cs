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
    public class QuotesFeedTests
    {
        private IGameMasterClient _gameMasterApi;
        private StartLevelResponse _startLevelResponse;

        public QuotesFeedTests()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Unable to Instantiate StockfighterApi. ApiKey is missing from application settings");
            }

            _gameMasterApi = new GameMasterClient(apiKey);
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
            Thread.Sleep(5000);
        }   

        [TestMethod]
        public void QuotesFeed_Returns_Quotes()
        {
            var quoteFeed = new QuotesFeed(_startLevelResponse.Account,_startLevelResponse.Venues.First(), false);
            var quotes = new List<QuoteFeedResponse>();

            quoteFeed.QuoteReceived += (sender, e) =>
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

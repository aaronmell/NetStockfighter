using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter.Client.Api;
using System;
using System.Configuration;
using System.Threading;

namespace Stockfighter.Api.IntigrationTests
{
    [TestClass]
    public class GameMasterTests
    {
        public GameMasterTests()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Unable to Instantiate StockfighterApi. ApiKey is missing from application settings");
            }

            gameMasterApi = new GameMasterClient(apiKey);
        }

        private IGameMasterClient gameMasterApi;

        [TestMethod]
        public void GameMaster_Start_Stop_Successful()
        {
            var start = gameMasterApi.StartLevelAsync("first_steps");

            start.Wait();

            Assert.IsTrue(start.Result.RequestSuccessful);

            var stop = gameMasterApi.StopLevelAsync(start.Result.InstanceId);

            stop.Wait();
        }

        [TestMethod]
        public void GameMaster_GetInstanceDetail_Successful()
        {
            var start = gameMasterApi.StartLevelAsync("first_steps");
            start.Wait();
            Assert.IsTrue(start.Result.RequestSuccessful);

            var resume = gameMasterApi.GetInstanceDetailAsync(start.Result.InstanceId);
            resume.Wait();
            Assert.IsTrue(resume.Result.RequestSuccessful);

            var stop = gameMasterApi.StopLevelAsync(start.Result.InstanceId);
            stop.Wait();
            Assert.IsTrue(stop.Result.RequestSuccessful);
        }

        [TestMethod]
        public void GameMaster_Resume_Successful()
        {
            var start = gameMasterApi.StartLevelAsync("first_steps");
            start.Wait();
            Assert.IsTrue(start.Result.RequestSuccessful);

            var resume = gameMasterApi.ResumeLevelAsync(start.Result.InstanceId);
            resume.Wait();
            Assert.IsTrue(resume.Result.RequestSuccessful);

            var stop = gameMasterApi.StopLevelAsync(start.Result.InstanceId);
            stop.Wait();
            Assert.IsTrue(stop.Result.RequestSuccessful);
        }

        [TestMethod]
        public void GameMaster_Restart_Successful()
        {
            var start = gameMasterApi.StartLevelAsync("first_steps");
            start.Wait();
            Assert.IsTrue(start.Result.RequestSuccessful);

            var resume = gameMasterApi.RestartLevelAsync(start.Result.InstanceId);
            resume.Wait();
            Assert.IsTrue(resume.Result.RequestSuccessful);

            var stop = gameMasterApi.StopLevelAsync(start.Result.InstanceId);
            stop.Wait();
            Assert.IsTrue(stop.Result.RequestSuccessful);
        }

        [TestInitialize]
        public void Run_Before_Each_Tests()
        {
            ///If we don't do this we will hit the rate limit
            Thread.Sleep(5000);
        }
    }
}

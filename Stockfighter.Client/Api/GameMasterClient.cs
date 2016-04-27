using System;
using System.Threading.Tasks;
using Stockfighter.Client.Data;
using Newtonsoft.Json;

namespace Stockfighter.Client.Api
{
    /// <summary>
    /// Concrete Implementation of the <see cref="IGameMasterClient"/> IGameMasterApi
    /// </summary>
    public class GameMasterClient : IGameMasterClient
    {
        private static HttpClientHelpers HttpClientHelpers;

        /// <summary>
        /// Creates a new instance of the <see cref="GameMasterClient"/>
        /// </summary>
        /// <param name="apiKey">The api key used to authenticate with stockfighter</param>
        public GameMasterClient(string apiKey)
        {           
            HttpClientHelpers = new HttpClientHelpers(new Uri("https://www.stockfighter.io/gm/"), apiKey);
        }


        /// <summary>
        /// Gets the details of a game instance asynchronously
        /// </summary>
        /// <param name="instanceId">The id of the instance</param>
        /// <returns><see cref="InstanceDetailsResponse"/></returns>
        public async Task<InstanceDetailsResponse> GetInstanceDetailAsync(int instanceId)
        {
            var result = await HttpClientHelpers.GetAsync(string.Format("instances/{0}", instanceId)).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<InstanceDetailsResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Restarst the instance asynchronously
        /// </summary>
        /// <param name="instanceId">The id of the instance being restarted</param>
        /// <returns><see cref="StartLevelResponse"/></returns>
        public async Task<StartLevelResponse> RestartLevelAsync(int instanceId)
        {
            var result = await HttpClientHelpers.PostAsync(string.Format("instances/{0}/restart", instanceId), null).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StartLevelResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Resumes a previously started instance. This returns the details about a running instance
        /// </summary>
        /// <param name="instanceId">The id of the instance to resume</param>
        /// <returns><see cref="StartLevelResponse"/></returns>
        public async Task<StartLevelResponse> ResumeLevelAsync(int instanceId)
        {
            var result = await HttpClientHelpers.PostAsync(string.Format("instances/{0}/resume", instanceId), null).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StartLevelResponse>(result)).ConfigureAwait(false);

        }

        /// <summary>
        /// Starts a level asynchronously
        /// </summary>
        /// <param name="levelName">The name of the level to start</param>
        /// <returns><see cref="StartLevelResponse"/></returns>
        public async Task<StartLevelResponse> StartLevelAsync(string levelName)
        {
            var result = await HttpClientHelpers.PostAsync(string.Format("levels/{0}", levelName), null).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<StartLevelResponse>(result)).ConfigureAwait(false);
        }

        /// <summary>
        /// Stops a level asynchronously
        /// </summary>
        /// <param name="instanceId">The id of the instance to be stopped</param>
        /// <returns><see cref="BaseResponse"/></returns>
        public async Task<BaseResponse> StopLevelAsync(int instanceId)
        {
            var result = await HttpClientHelpers.PostAsync(string.Format("instances/{0}/stop", instanceId), null).ConfigureAwait(false);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<BaseResponse>(result)).ConfigureAwait(false);
        }
    }
}

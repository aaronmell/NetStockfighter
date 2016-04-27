using Stockfighter.Client.Data;
using System.Threading.Tasks;

namespace Stockfighter.Client.Api
{
    /// <summary>
    /// Describes the Http Requests that can be made to the game master. 
    /// This allows you to run the game automatically.
    /// </summary>
    public interface IGameMasterClient
    {
        Task<StartLevelResponse> StartLevelAsync(string levelName);

        Task<StartLevelResponse> RestartLevelAsync(int instanceId);

        Task<BaseResponse> StopLevelAsync(int instanceId);

        Task<StartLevelResponse> ResumeLevelAsync(int instanceId);

        Task<InstanceDetailsResponse> GetInstanceDetailAsync(int instanceId);
    }
}

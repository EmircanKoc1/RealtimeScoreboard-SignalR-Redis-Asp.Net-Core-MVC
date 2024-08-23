using Microsoft.AspNetCore.SignalR;
using RealtimeScoreBoard.WebApp.HubTypes;
using RealtimeScoreBoard.WebApp.Services;

namespace RealtimeScoreBoard.WebApp.Hubs
{
    public class ScoreboardHub : Hub<INotifyType>
    {
        private readonly IScoreboardService _scoreBoardService;

        public ScoreboardHub(IScoreboardService scoreboardService)
        {
            _scoreBoardService = scoreboardService;
        }

        public async Task IncreaseScoreboardScore(string member, double score)
        {
            await _scoreBoardService.IncreaseScoreAsync(member, score);
            _scoreBoardService.GetScoreWithMembersAsync();
            await Clients.All.ReceiveScoreUpdate();
        }

        public async Task DecreaseScoreboardScore()
        {

            await Clients.All.ReceiveScoreUpdate();
        }

        public async Task UpdateScoreboardScore()
        {

            await Clients.All.ReceiveScoreUpdate();
        }
    }
}

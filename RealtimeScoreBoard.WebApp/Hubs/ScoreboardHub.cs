using Microsoft.AspNetCore.SignalR;
using RealtimeScoreBoard.WebApp.HubTypes;
using RealtimeScoreBoard.WebApp.Services;

namespace RealtimeScoreBoard.WebApp.Hubs
{
    public class ScoreboardHub : Hub<INotifyType> , IScoreboardHub
    {
        private readonly IScoreboardService _scoreBoardService;
        private static long connectedClient = 0;
        public ScoreboardHub(IScoreboardService scoreboardService)
        {
            _scoreBoardService = scoreboardService;
        }

        public async Task IncreaseScoreboardScore(string member, double score)
        {

            await _scoreBoardService.IncreaseScoreAsync(member, score);
            var result = await _scoreBoardService.GetScoreWithMembersAsync();
            await Clients.All.ReceiveScoreboardScores(result);

        }

        public async Task DecreaseScoreboardScore(string member, double score)
        {

            await _scoreBoardService.DecreaseScoreAsync(member, score);
            var result = await _scoreBoardService.GetScoreWithMembersAsync();
            await Clients.All.ReceiveScoreboardScores(result);

        }

        public async Task UpdateScoreboardScore(string member, double score)
        {

            await _scoreBoardService.UpdateScoreAsync(member, score);
            var result = await _scoreBoardService.GetScoreWithMembersAsync();
            await Clients.All.ReceiveScoreboardScores(result);

        }

        public async Task FirstLoadingScoreboardScore()
        {
            var result = await _scoreBoardService.GetScoreWithMembersAsync();
            await Clients.All.ReceiveScoreboardScores(result);

        }

        public async override Task OnConnectedAsync()
        {
            Interlocked.Increment(ref connectedClient);
            await Clients.All.ReceiveConnectedClientCount(connectedClient);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Interlocked.Decrement(ref connectedClient);
            await Clients.All.ReceiveConnectedClientCount(connectedClient);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

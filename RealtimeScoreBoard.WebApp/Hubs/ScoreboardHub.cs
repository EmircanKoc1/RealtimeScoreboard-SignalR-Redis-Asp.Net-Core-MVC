using Microsoft.AspNetCore.SignalR;
using RealtimeScoreBoard.WebApp.Contexts;
using RealtimeScoreBoard.WebApp.HubTypes;
using RealtimeScoreBoard.WebApp.Services;

namespace RealtimeScoreBoard.WebApp.Hubs
{
    public class ScoreboardHub : Hub<INotifyType>
    {
        private readonly IRedisPubSubService _redisPubSubService;
        private readonly RedisContext _redisContext;
        public ScoreboardHub(IRedisPubSubService redisPubSubService, RedisContext redisContext)
        {
            _redisPubSubService = redisPubSubService;
            _redisContext = redisContext;
        }

        public async Task IncreaseScoreboardScore()
        {

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

namespace RealtimeScoreBoard.WebApp.Hubs
{
    public interface IScoreboardHub
    {
        Task IncreaseScoreboardScore(string member, double score);
        Task DecreaseScoreboardScore(string member, double score);
        Task UpdateScoreboardScore(string member, double score);
        Task FirstLoadingScoreboardScore();
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception? exception);
    }
}

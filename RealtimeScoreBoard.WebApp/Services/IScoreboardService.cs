namespace RealtimeScoreBoard.WebApp.Services
{
    public interface IScoreboardService
    {
        Task IncreaseScoreAsync(string member, int score);
        Task DecreaseScoreAsync(string member, int score);
        Task UpdateScoreAsync(string member, int score);

        Task<IEnumerable<ValueTuple<string, string>>> GetScoreWithMembersAsync(string key);
    }
}

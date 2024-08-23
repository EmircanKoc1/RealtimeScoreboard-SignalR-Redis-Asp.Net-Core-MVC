namespace RealtimeScoreBoard.WebApp.Services
{
    public interface IScoreboardService
    {
        Task IncreaseScoreAsync(string member, double score);
        Task DecreaseScoreAsync(string member, double score);
        Task UpdateScoreAsync(string member, double score);

        Task<IEnumerable<KeyValuePair<string, string>>> GetScoreWithMembersAsync();
    }
}

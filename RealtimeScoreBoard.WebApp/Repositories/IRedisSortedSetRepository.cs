namespace RealtimeScoreBoard.WebApp.Repositories
{
    public interface IRedisSortedSetRepository
    {
        public Task IncreaseScore(string key, string member, double score);

        public Task DecreaseScore(string key, string memeber, double score);

        public Task UpdateScore(string key, string member, double score);

        public Task<IEnumerable<KeyValuePair<string, string>>> GetScoresWithMembers(string key);

    }
}

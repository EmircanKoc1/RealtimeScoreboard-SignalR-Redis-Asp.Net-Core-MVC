
using RealtimeScoreBoard.WebApp.Contexts;
using StackExchange.Redis;

namespace RealtimeScoreBoard.WebApp.Repositories
{
    public class RedisSortedSetRepository : IRedisSortedSetRepository /*, IDisposable*/
    {
        private readonly RedisContext _context;
        private readonly IDatabase _database;
        public RedisSortedSetRepository(RedisContext context)
        {
            _context = context;
            _database = context.GetDatabase();
        }

        public async Task DecreaseScore(string key, string member, double score)
        {
            await _database.SortedSetDecrementAsync(key, member, score);
        }

        

        public async Task<IEnumerable<(string, string)>?> GetScoresWithMembers(string key)
        {
            var membersWithScores = await _database.SortedSetRangeByRankWithScoresAsync(key);

            return membersWithScores.Select(sse => 
            ValueTuple.Create<string, string>(sse.Element, sse.Score.ToString()));

        }

        public async Task IncreaseScore(string key, string member, double score)
        {
            await _database.SortedSetIncrementAsync(key, member, score);
        }

        public async Task UpdateScore(string key, string member, double score)
        {
            await _database.SortedSetAddAsync(key, member, score);
            
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}

using StackExchange.Redis;

namespace RealtimeScoreBoard.WebApp.Contexts
{
    public class RedisContext : IDisposable
    {
        protected ConnectionMultiplexer _multiplexer;
        public ConnectionMultiplexer ConnectionMultiplexer => _multiplexer;

        public RedisContext(string connectionString)
            => _multiplexer = ConnectionMultiplexer.Connect(connectionString);

        public RedisContext(ConfigurationOptions options)
            => _multiplexer = ConnectionMultiplexer.Connect(options);


        public IDatabase GetDatabase()
            => _multiplexer.GetDatabase();

        public void Dispose()
        {
           ConnectionMultiplexer.Dispose();
        }
    }
}

namespace RealtimeScoreBoard.WebApp.HubTypes
{
    public interface INotifyType
    {
        Task ReceiveScoreboardScores(IEnumerable<KeyValuePair<string, string>> membersWithScores);

        Task ReceiveConnectedClientCount(long connectedCount);
    }
}

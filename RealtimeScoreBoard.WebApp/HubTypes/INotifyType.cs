namespace RealtimeScoreBoard.WebApp.HubTypes
{
    public interface INotifyType
    {
        Task ReceiveScoreUpdate();

    }
}

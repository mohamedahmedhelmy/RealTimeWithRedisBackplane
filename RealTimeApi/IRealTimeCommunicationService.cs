
namespace RealTimeApi
{
    public interface IRealTimeCommunicationService
    {
        Task SendMessageToAllUsersAsync(object message);
        Task SendMessageToGroupAsync(string groupName, object message);
        Task SendMessageToUserAsync(string userId, object message);
    }
}
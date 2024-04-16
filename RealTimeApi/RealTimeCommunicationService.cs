using Microsoft.AspNetCore.SignalR;
using Northwind.SignalR.Service.Hubs;
using StackExchange.Redis;

namespace RealTimeApi
{
    public class RealTimeCommunicationService : IRealTimeCommunicationService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public RealTimeCommunicationService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToUserAsync(string userId, object message)
        {
            // Implement logic to get connection IDs for the user
          //  var connectionIds = GetConnectionIdsForUser(userId);
            //if (connectionIds != null && connectionIds.Count > 0)
            //{
                await _hubContext.Clients.Client(userId).SendAsync("ReceiveMessage", message);
            //}
        }

        public async Task SendMessageToAllUsersAsync(object message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessageToGroupAsync(string groupName, object message)
        {
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", message);
        }
        

        private List<string> GetConnectionIdsForUser(string userId)
        {
            // Implement logic to retrieve connection IDs for the specified user
            // This could involve querying a database or an in-memory store
            // For simplicity, let's assume a method GetConnectionIdsForUser exists
            return new List<string>(); // Dummy return, replace with actual logic
        }
    }
}

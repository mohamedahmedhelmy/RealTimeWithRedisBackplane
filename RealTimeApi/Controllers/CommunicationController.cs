using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Northwind.Chat.Models;
using Northwind.SignalR.Service.Hubs;
using RealTimeApi.Models;
using System.Text.Json;

namespace RealTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        //private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRealTimeCommunicationService _realTimeCommunicationService;   
        public CommunicationController(IRealTimeCommunicationService realTimeCommunicationService)
        {
            _realTimeCommunicationService = realTimeCommunicationService;
            //_hubContext = hubContext;
        }

        [HttpPost("sendToUser")]
        public async Task<IActionResult> SendMessageToUser([FromBody] MessageModel message)
        {
            await _realTimeCommunicationService.SendMessageToUserAsync(message.To, message);
            return Ok();
        }

        [HttpPost("sendToAll")]
        public async Task<IActionResult> SendMessageToAll(MessageModel message)
        {

            // var msg = JsonSerializer.Serialize<MessageModel>(message);
            await _realTimeCommunicationService.SendMessageToAllUsersAsync(message);
            //await _hubContext.Clients.Client(message.To).SendAsync("ReceiveMessage", message);
            return Ok();
        }

        [HttpPost("sendToGroup")]
        public async Task<IActionResult> SendMessageToGroup([FromBody]MessageModel message)
        {
            await _realTimeCommunicationService.SendMessageToGroupAsync(message.To, message);
            return Ok();
        }
    }
}

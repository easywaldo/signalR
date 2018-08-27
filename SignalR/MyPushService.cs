using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR
{
    public class MyPushService : Hub
    {
        [HubMethodName("SendMessage")]
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("SendMessageOut", "hello");
        }
    }
}

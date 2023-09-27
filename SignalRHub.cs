using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1234567890
{
    public class SignalRHub : Hub
    {
        public void BroadcastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", message);
        }

       /* [FunctionName(nameof(SendToUser))]
        public async Task SendToUser([SignalRTrigger] InvocationContext invocationContext, string userName, string message)
        {
            await Clients.User("admin@admin.com").SendAsync("new_message", message);
        }*/
    }
}

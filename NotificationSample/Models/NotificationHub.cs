using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace NotificationSample.Models
{
    public class NotificationHub: Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
       
    }
}
   
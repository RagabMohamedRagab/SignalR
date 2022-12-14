using Microsoft.AspNetCore.SignalR;

namespace Notifcations.Hubs {
    public class ChatHub :Hub{
        public async Task SendNotifcation()
        {
           await Clients.All.SendAsync("Notifcation");
        }
    }
}

using Microsoft.AspNetCore.SignalR;

namespace Notifcations.Hubs {
    public class ChatHub:Hub {
        // send message to all users
        public async Task SendMessageToAllUsers(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}

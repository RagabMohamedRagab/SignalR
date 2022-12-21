using Microsoft.AspNetCore.SignalR;
using Notifcations.Hubs.ServicesHub;

namespace Notifcations.Hubs
{
    public class NotificationUserHub:Hub {
        private readonly IUserConnectionManager _userConnectionManager;

        public NotificationUserHub(IUserConnectionManager userConnectionManager)
        {
            _userConnectionManager = userConnectionManager;
        }
        public string GetConnectionId()
        {
            var httpcontext=this.Context.GetHttpContext();
            var userId = httpcontext.Request.Query["userId"];
            _userConnectionManager.KeepUserConnection(userId, Context.ConnectionId);
            return Context.ConnectionId;
        }
        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            // Get ConnnectionId
            var connectionId=Context.ConnectionId;
            _userConnectionManager.RemoveUserConnection(connectionId);
            var value=await Task.FromResult(0);
        }
    }
}

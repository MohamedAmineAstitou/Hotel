
using Microsoft.AspNetCore.SignalR;


namespace Hotel_Astitou_Backend.Notify
{
    public class NotificationHub : Hub
    {
        public void NotifyAllClient(Notification message)
        {
            Clients.All.SendAsync("notification", message);
        }
    }

}

using Hotel_Astitou_Backend.Notify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Controllers
{
    
    [Route("notifications")]
    public class NotificationController : AuthorizeController
    {
        private IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [AllowAnonymous]
        [HttpPost]
        public void GenerateNotification()
        {
            _hubContext.Clients.All.SendAsync("notification",
                new Notification
                {
                    Text = "Test SignalR",
                    Duration = 1000,
                    Type = NotificationType.Alert
                });
        }
    }
}

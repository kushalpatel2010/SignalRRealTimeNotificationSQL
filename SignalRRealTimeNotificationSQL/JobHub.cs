using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRRealTimeNotificationSQL
{
    public class JobHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<JobHub>();
            context.Clients.All.displayStatus();
        }
    }
}
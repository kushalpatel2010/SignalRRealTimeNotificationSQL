using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SignalRRealTimeNotificationSQL
{
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {

        public void SendNotification(string message, string user)
        {
            //Create an instance of the Repository class
            NotificationRepository objRepository = new NotificationRepository();

            //Invoke the Add Notification method that we created in the repository to add the notification to the database 
            objRepository.AddNotification(message, user);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            //Create an instance of the Repository class
            NotificationRepository objRepository = new NotificationRepository();

            //refreshNotification is the client side method which will be writing in the future section. GetLogin() is a static extensions extract just the login name scrapping the domain name 
            Clients.User(Context.User.Identity.Name).refreshNotification(objRepository.GetNotifications(Context.User.Identity.Name));

            return base.OnConnected();

        }


    }

    public static class Extensions
    {
        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
}
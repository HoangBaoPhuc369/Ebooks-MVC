using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebooks.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            //call the addNewMessagePage method to update clients
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}
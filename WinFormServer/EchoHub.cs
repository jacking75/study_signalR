using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace WinFormServer
{
    public class EchoHub : Hub
    {
        public Task Broadcast(string message)
        {
            var timestamp = DateTime.Now.ToString();
            return this.Clients.All.SendAsync("Receive", message, timestamp);
        }
    }
}

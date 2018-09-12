using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace EchoServer2
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
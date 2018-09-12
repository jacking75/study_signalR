using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace WinFormServer
{
    public class EchoHub : Hub
    {
        int Count = 0;

        public override Task OnConnectedAsync()
        {            
            Interlocked.Increment( ref Count);
            DevLog.Write($"Client: {Context.ConnectionId}, Total: {Count}", LOG_LEVEL.INFO);

            base.OnConnectedAsync();
            //Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Interlocked.Decrement(ref Count);
            DevLog.Write($"Client: {Context.ConnectionId}, Total: {Count}", LOG_LEVEL.INFO);

            base.OnDisconnectedAsync(exception);
            //Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public Task Broadcast(string message)
        {
            var timestamp = DateTime.Now.ToString();
            return this.Clients.All.SendAsync("Receive", message, timestamp);
        }
    }
}

﻿using System;
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
        static int Count2 = 0;
        int Count = 0;

        public override Task OnConnectedAsync()
        {
            base.OnConnectedAsync();

            Interlocked.Increment( ref Count);
            Interlocked.Increment(ref Count2);

            DevLog.Write($"Client: {Context.ConnectionId}, [Count: {Count}], [Count2: {Count2}]", LOG_LEVEL.INFO);
            
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            base.OnDisconnectedAsync(exception);

            Interlocked.Decrement(ref Count);
            Interlocked.Decrement(ref Count2);

            DevLog.Write($"Client: {Context.ConnectionId}, [Count: {Count}], [Count2: {Count2}]", LOG_LEVEL.INFO);

            return Task.CompletedTask;
        }

        public Task Broadcast(string message)
        {
            var timestamp = DateTime.Now.ToString();
            return this.Clients.All.SendAsync("Receive", message, timestamp);
        }

        public Task SelfKickOff()
        {
            DevLog.Write($"SelfKickOff. Client: {Context.ConnectionId}", LOG_LEVEL.INFO);

            Context.Abort();            
            return Task.CompletedTask;
        }
    }
}
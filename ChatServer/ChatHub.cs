using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace ChatServer
{
    public class ChatHub : Hub
    {
        readonly RoomManager roomManager;

        public ChatHub(RoomManager _roomManager)
        {
            roomManager = _roomManager;
        }

        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("Send", $"{Context.ConnectionId} joined");
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await Clients.Others.SendAsync("Send", $"{Context.ConnectionId} left");
        //}

        // 모두에게
        public Task SendBroadCast(string message)
        {
            return Clients.All.SendAsync("Send", $"{Context.ConnectionId}: {message}");
        }

        // 나 이외의 모든 클라에게
        public Task SendToOthers(string message)
        {
            return Clients.Others.SendAsync("Send", $"{Context.ConnectionId}: {message}");
        }

        //귓속말
        public Task SendToConnection(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("Send", $"Private message from {Context.ConnectionId}: {message}");
        }

        public Task SendToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}@{groupName}: {message}");
        }

        public Task SendToOthersInGroup(string groupName, string message)
        {
            return Clients.OthersInGroup(groupName).SendAsync("Send", $"{Context.ConnectionId}@{groupName}: {message}");
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} joined {groupName}");
        }

        public async Task LeaveGroup(string groupName)
        {
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} left {groupName}");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public Task Echo(string message)
        {
            return Clients.Caller.SendAsync("Send", $"{Context.ConnectionId}: {message}");
        }
    }
}

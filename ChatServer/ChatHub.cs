using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace ChatServer
{
    public class ChatHub : Hub
    {
        readonly RoomManager RoomMgr;

        public ChatHub(RoomManager _roomManager)
        {
            RoomMgr = _roomManager;
        }

        public override Task OnConnectedAsync()
        {
            RoomMgr.NewConnectedClient(Context.ConnectionId);

            Console.WriteLine($"New Connected Client: {Context.ConnectionId}");
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception ex)
        {
            RoomMgr.DisConnectedClient(Context.ConnectionId);

            Console.WriteLine($"DisConnected Client: {Context.ConnectionId}");
            return Task.CompletedTask;
        }


        // 닉네임 설정
        public Task ChangeNickName(string nickName)
        {
            return Clients.Caller.SendAsync("ResChangeNickName", ErrorCode.NONE);
        }

        // 방 입장
        public async Task RoomEnter(int roomNumber)
        {
            if(RoomMgr.ValidRoomNumber(roomNumber) == false)
            {
                await Clients.Caller.SendAsync("ResRoomEnter", ErrorCode.ROOM_ENTER_INVALID_ROOM_NUMBER);
                return;
            }

            var result = RoomMgr.UserEnterRoom(Context.ConnectionId, roomNumber);

            var groupName = roomNumber.ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Caller.SendAsync("ResRoomEnter", result);
        }

        // 방 나가기
        public async Task RoomLeave()
        {
            var result = RoomMgr.UserLeaveRoom(Context.ConnectionId);
            await Clients.Caller.SendAsync("ResRoomLeave", result.Item2);

            if (result.Item2 == ErrorCode.NONE)
            {
                var groupName = result.Item1.ToString();
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            }
        }

        // 방 채팅
        public Task RoomChat(string message)
        {
            var nickName = Context.ConnectionId;
            var roomNumber = RoomMgr.UserRoomNumber(Context.ConnectionId);

            if( roomNumber == -1)
            {
                return Clients.Caller.SendAsync("ResRoomChat", ErrorCode.ROOM_CHAT_NOT_IN_ROOM);
            }
            else
            {
                nickName = RoomMgr.GetUserNickName(Context.ConnectionId);
                Clients.Caller.SendAsync("ResRoomChat", ErrorCode.NONE);
            }            

            return Clients.GroupExcept(roomNumber.ToString(), Context.ConnectionId).SendAsync("NtfRoomChat", nickName, message);
        }



        // 모두에게
        // return Clients.All.SendAsync("Send", $"{Context.ConnectionId}: {message}");

        // 나 이외의 모든 클라에게
        // return Clients.Others.SendAsync("Send", $"{Context.ConnectionId}: {message}");

        // 특정 유저만 제외하고 싶은 경우
        //AllExcept(IReadOnlyList<string> excludedConnectionIds);

        // 지정한 클라이언트에만 보내기
        // return Clients.Client(connectionId).SendAsync("Send", $"Private message from {Context.ConnectionId}: {message}");

        // 그룹 내의 모든 클라에게
        // return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}@{groupName}: {message}");

        // 특정 그룹을 제외한 모든 클라에게
        // return Clients.OthersInGroup(groupName).SendAsync("Send", $"{Context.ConnectionId}@{groupName}: {message}");

        // 모든 클라이언트에게 통보
        // return Clients.Caller.SendAsync("Send", $"{Context.ConnectionId}: {message}");       
    }
}

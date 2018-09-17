using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;


namespace ChatServer
{
    public class RoomManager
    {
        IHubContext<ChatHub> Hub;

        ConcurrentDictionary<string, UserInfo> ConnectedUsers = new ConcurrentDictionary<string, UserInfo>();

        //List<Room> RoomList = new List<Room>();

        int MaxRoomNumber = 0;


        public RoomManager(IHubContext<ChatHub> hub)
        {
            Hub = hub;
            Init(10);
        }

        void Init(int maxRoomCount)
        {
            MaxRoomNumber = maxRoomCount;
            //for (int i = 0; i < maxRoomCount; i++)
            //{
            //    var room = new Room();
            //    RoomList.Add(room);
            //}
        }


        public void NewConnectedClient(string connectedId)
        {
            var userInfo = new UserInfo(connectedId);
            ConnectedUsers.TryAdd(connectedId, userInfo);
        }

        public void DisConnectedClient(string connectedId)
        {
            ConnectedUsers.TryRemove(connectedId, out var value);
        }


        public bool ChangeuserNickName(string connectedId, string nickName)
        {
            ConnectedUsers.TryGetValue(connectedId, out var userInfo);

            if( userInfo.IsInRoom())
            {
                return false;
            }

            return true;
        }

        public bool ValidRoomNumber(int roomNumber)
        {
            if(roomNumber < 0 || roomNumber >= MaxRoomNumber)
            {
                return false;
            }

            return true;
        }

        public ErrorCode UserEnterRoom(string connectedId, int roomNumber)
        {
            ConnectedUsers.TryGetValue(connectedId, out var userInfo);

            if(userInfo.IsInRoom())
            {
                return ErrorCode.ROOM_ENTER_ALREADY_IN_ROOM;
            }

            userInfo.StateEnterRoom(roomNumber);
            return ErrorCode.NONE;
        }

        public (int, ErrorCode) UserLeaveRoom(string connectedId)
        {
            ConnectedUsers.TryGetValue(connectedId, out var userInfo);

            if (userInfo.IsInRoom() == false)
            {
                return (-1, ErrorCode.ROOM_LEAVE_NOT_IN_ROOM);
            }

            var roomNumber = userInfo.GetRoomNumber();
            userInfo.StateLeaveRoom();

            return (roomNumber, ErrorCode.NONE);
        }

        public int UserRoomNumber(string connectedId)
        {
            ConnectedUsers.TryGetValue(connectedId, out var userInfo);

            if (userInfo.IsInRoom() == false)
            {
                return -1;
            }

            return userInfo.GetRoomNumber();
        }

    }
}

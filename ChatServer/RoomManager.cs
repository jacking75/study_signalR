using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;


namespace ChatServer
{
    public class RoomManager
    {
        IHubContext<ChatHub> Hub;
        List<Room> RoomList = new List<Room>();

        public RoomManager(IHubContext<ChatHub> hub)
        {
            Hub = hub;
            Init(10);
        }

        void Init(int maxRoomCount)
        {
            var room = new Room();
            RoomList.Add(room);
        }
    }
}

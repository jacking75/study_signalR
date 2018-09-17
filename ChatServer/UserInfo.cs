using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer
{
    public class UserInfo
    {
        object lockObject = new object();

        string ConnecteId;
        string NickName;

        int RoomNumber = -1;
        
        public UserInfo(string connectId)
        {
            ConnecteId = connectId;
        }

        public void ChangeNickName(string nickName)
        {
            NickName = nickName;
        }

        public void StateEnterRoom(int roomNumber)
        {
            RoomNumber = roomNumber;
        }

        public void StateLeaveRoom()
        {
            RoomNumber = -1;
        }

        public bool IsInRoom()
        {
            return RoomNumber != -1 ? true : false;
        }

        public int GetRoomNumber() { return RoomNumber;  }



    }
}

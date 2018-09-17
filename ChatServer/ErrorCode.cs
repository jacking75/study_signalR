using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer
{    
    public enum ErrorCode
    {
        NONE = 1,

        ROOM_ENTER_INVALID_ROOM_NUMBER = 111,
        ROOM_ENTER_ALREADY_IN_ROOM = 112,
        ROOM_LEAVE_NOT_IN_ROOM = 114,
        ROOM_CHAT_NOT_IN_ROOM = 115,
    }
}

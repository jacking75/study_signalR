using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace EchoServer
{
    // 동적 타입 사용
    public class EchoHub1 : DynamicHub
    {
        public Task Broadcast(string message)
        {
            var timestamp = DateTime.Now.ToString();
            //return this.Clients.All.SendAsync("Receive", message, timestamp);
            return this.Clients.All.EchoReceive(Context.ConnectionId, message, timestamp);
        }
    }
    

    public class EchoHub2 : Hub<ICallbackClient>
    {
        public Task Broadcast(string message)
        {
            var timestamp = DateTime.Now.ToString();
            return this.Clients.All.EchoReceive(Context.ConnectionId, message, timestamp);
        }
    }

    // EchoReceive 함수를 구현한 코드를 서버와 클라이언트가 같이 사용하고 싶을 때 좋다
    public interface ICallbackClient
    {
        Task EchoReceive(string sender, string message, string timestamp);
        
    }
}

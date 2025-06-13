using System.Net;
using System.Net.Sockets;
using System.Text;

#region  使用socket原生类
//ProtocolType通讯协议类型
//SocketType套接字类型
var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
var remoteEndPoint = new IPEndPoint(IPAddress.Loopback, 7788);

while (true)
{
    var message = "Hello, Server!";
    var buffer = Encoding.UTF8.GetBytes(message);
    socket.SendTo(buffer, remoteEndPoint);

    System.Console.WriteLine($"Client send a message : {message}.{DateTime.Now}");
    await Task.Delay(1000);
}
#endregion
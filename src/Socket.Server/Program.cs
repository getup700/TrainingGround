using System.Net;
using System.Net.Sockets;
using System.Text;

#region  使用socket原生类
// //ProtocolType通讯协议类型
// //SocketType套接字类型
// var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
// var remoteEndPoint = new IPEndPoint(IPAddress.Loopback, 7788);
// socket.Bind(remoteEndPoint);

// while (true)
// {
//     var buffer = new byte[1024];
//     EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
//     //这句代码会阻塞线程
//     var bytesRead = socket.ReceiveFrom(buffer, ref senderEndPoint);
//     string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
//     Console.WriteLine($"Received from server: {receivedMessage}.{DateTime.Now}");

//     await Task.Delay(1);
// }
#endregion


#region 使用UpdClient

var udpClient = new UdpClient(7788);
IPEndPoint endPoint = null;
while (true)
{
    var buffer = udpClient.Receive(ref endPoint);
    var message = Encoding.UTF8.GetString(buffer);
    System.Console.WriteLine($"Received from 7788 :{message}");


}

#endregion
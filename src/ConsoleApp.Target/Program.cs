using System.IO.Pipes;
using System.Text;


// 客户端
//using var clientPipe = new NamedPipeClientStream(
//    ".",
//    "testpipe",
//    PipeDirection.InOut);
//await clientPipe.ConnectAsync();
//Console.WriteLine("Connecting to server...");
//Console.WriteLine(clientPipe.IsConnected);
//while (true)
//{
//    byte[] buffer = new byte[1024];
//    int bytesRead = await clientPipe.ReadAsync(buffer, 0, buffer.Length);
//    string messageFromServer = Encoding.UTF8.GetString(buffer, 0, bytesRead);
//    Console.WriteLine($"Received from server: {messageFromServer}");
//}

using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
    arguments: null);

const string message = "Hello World!";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
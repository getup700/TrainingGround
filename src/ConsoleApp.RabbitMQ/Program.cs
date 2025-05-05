// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

// 创建连接工厂
var factory = new ConnectionFactory() { HostName = "localhost" };

// 创建连接
using var connection = await factory.CreateConnectionAsync();
// 创建通道
using var channel = await connection.CreateChannelAsync();
// 声明队列
await channel.QueueDeclareAsync(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

// 要发送的消息
string message = "Hello, RabbitMQ from C#!";
var body = Encoding.UTF8.GetBytes(message);
var body1 = new ReadOnlyMemory<byte>(body);
// 发布消息
//await channel.BasicPublishAsync<IReadOnlyBasicProperties>(exchange: "",
//    routingKey:"hello",
//    mandatory:true,
//    basicProperties: ,
//    body: body1);

System.Console.WriteLine($" [x] Sent '{message}'");

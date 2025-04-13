// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

var redis = ConnectionMultiplexer.Connect("39.106.54.114");
var db = redis.GetDatabase();

//db.StringSet("myKey", "Hello,Redis!");
var value = db.StringGet("myKey");
Console.WriteLine(value);

redis.Close();
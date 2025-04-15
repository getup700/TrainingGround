using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using WpfApp.Communication.Client1.Models;

namespace WpfApp.Communication.Client1.Services;

internal class ChatRecordService : IChatRecordService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _db;
    private readonly IConfiguration _configuration;

    public ChatRecordService(IConfiguration configuration)
    {
        _configuration = configuration;
        _redis = ConnectionMultiplexer.Connect(RedisConnString(configuration));
        _db = _redis.GetDatabase();
    }

    public async Task AddChatRecordAsync(Message message)
    {
        var chatRoomKey = GetChatKey(message.Sender, message.Receiver);

        await _db.HashSetAsync(chatRoomKey, "message", JsonSerializer.Serialize(message));
    }

    public async Task<List<Message>> GetChatRecordsAsync(string user1, string user2, int start, int count)
    {
        var chatRoomKey = GetChatKey(user1, user2);
        var messages = await _db.HashGetAllAsync(chatRoomKey);
        if (messages.Length == 0)
        {
            return new List<Message>();
        }

        return [];
    }

    private string GetChatKey(string user1, string user2)
    {
        var sortedUsers = new[] { user1, user2 }.Order().ToArray();
        return $"chat:{sortedUsers[0]}:{sortedUsers[1]}";
    }

    public void Dispose()
    {
        _redis.Close();
    }

    private string RedisConnString(IConfiguration configuration)
    {
        var redisHost = configuration.GetSection("ChatRecordRedis:Host").Value;
        var redisPort = configuration.GetValue<int>("ChatRecordRedis:Port");
        var redisPassword = configuration.GetSection("ChatRecordRedis:Password").Value;
        return $"{redisHost}:{redisPort},password={redisPassword}";
    }
}

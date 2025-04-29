using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using WpfApp.Communication.Client1.Models;

namespace WebApplication1.SignalR.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;
    private readonly Dictionary<string, string> _connections = [];

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public async Task SendStringMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveStringMessage", user, message);
        _logger.LogInformation($"{user} send a message:<{message}> to everyone");
    }

    public async Task SendPrivateStringMessage(string user, string receiver, string message)
    {
        await Clients.User(receiver).SendAsync("ReceivePrivateMessage", user, message);
        _logger.LogInformation($"{user} send a message:<{message}> to {receiver}");
    }

    public async Task SendMessage(Message message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);

        _logger.LogInformation($"{message.Sender} send a message:<{JsonSerializer.Serialize(message)}> to {message.Receiver}");
    }

    public override Task OnConnectedAsync()
    {
        var userName = Context.User.Identity?.Name;
        if (userName != null)
        {
            _connections[Context.ConnectionId] = userName;
            Clients.All.SendAsync("UserConnected", userName);
            _logger.LogInformation($"{userName} connected to the chat hub.");
        }
        else
        {
            _logger.LogWarning("User name is null. Connection ID: {ConnectionId}", Context.ConnectionId);
        }
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        if (_connections.ContainsKey(Context.ConnectionId))
        {
            var userName = _connections[Context.ConnectionId];
            _connections.Remove(Context.ConnectionId);
            Clients.All.SendAsync("UserDisconnected", userName);
            _logger.LogInformation($"{userName} disconnected from the chat hub.");
        }
        else
        {
            _logger.LogWarning("Connection ID {ConnectionId} not found in connections.", Context.ConnectionId);
        }
        return base.OnDisconnectedAsync(exception);
    }

    public IEnumerable<string> GetSubscribedUsers()
    {
        return _connections.Values.Distinct();
    }
}

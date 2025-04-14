using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
        _logger.LogInformation($"{user} send a message:<{message}> to everyone");
    }

    public async Task SendTargetMessage(string user, string targetUser, string message)
    {
        await Clients.User(targetUser).SendAsync("DDDMessage", user, message);
        _logger.LogInformation($"{user} send a message:<{message}> to {targetUser}");
    }
}

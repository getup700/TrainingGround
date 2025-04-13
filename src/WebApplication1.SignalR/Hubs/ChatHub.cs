using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR.Hubs;

public class ChatHub:Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
        _logger.LogInformation("Message sent: {user}: {message}", user, message);
    }
}

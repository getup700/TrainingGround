using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR.Hubs;

public class GroupedChatHub:Hub
{
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendGroupMessage(string groupName, string user, string message)
    {
        await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", user, message);
    }
}

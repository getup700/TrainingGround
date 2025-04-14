using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR.Hubs;

public class AuthorizedHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        // 进行身份验证和权限检查
        if (!IsAuthorized(Context.ConnectionId))
        {
            Context.Abort();
            return;
        }
        await base.OnConnectedAsync();
    }

    private bool IsAuthorized(string connectionId)
    {
        // 实现身份验证和权限检查逻辑
        // 例如，检查用户是否登录，是否具有特定角色等
        return true;
    }
}
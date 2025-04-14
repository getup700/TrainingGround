using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR.Hubs;

public class DataSubscriptionHub : Hub
{
    private readonly Dictionary<string, List<string>> _subscriptions = new Dictionary<string, List<string>>();

    public async Task Subscribe(string dataType)
    {
        if (!_subscriptions.ContainsKey(dataType))
        {
            _subscriptions[dataType] = new List<string>();
        }
        _subscriptions[dataType].Add(Context.ConnectionId);
    }

    public async Task Unsubscribe(string dataType)
    {
        if (_subscriptions.ContainsKey(dataType))
        {
            _subscriptions[dataType].Remove(Context.ConnectionId);
        }
    }

    public async Task PushData(string dataType, object data)
    {
        if (_subscriptions.ContainsKey(dataType))
        {
            foreach (var connectionId in _subscriptions[dataType])
            {
                await Clients.Client(connectionId).SendAsync("ReceiveData", dataType, data);
            }
        }
    }
}

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using WpfApp.Communication.Client1.Models;

namespace WpfApp.Communication.Client1.ViewModels;

internal partial class MainWindowViewModel : ObservableObject
{
    private HubConnection _hubConnection;

    public MainWindowViewModel(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
        InitializeHubConnection();
        Friends.Add(new User() { Name = "omar" });
        Friends.Add(new User() { Name = "dan", IsOnLine = true });
    }

    public ObservableCollection<User> Friends { get; set; } = [];

    [ObservableProperty]
    User _currentChatUser = new();

    [ObservableProperty]
    User _me = new();

    public ObservableCollection<Message> Messages { get; set; } = [];

    [ObservableProperty]
    string _sourceUser = "client1";

    [ObservableProperty]
    string _targetUser;

    [ObservableProperty]
    string _inputMessage;

    [ObservableProperty]
    string _newFriendName;


    private async Task InitializeHubConnection()
    {
        _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new Message()
                {
                    Source = user,
                    Content = message,
                    Description = "远程接收到的消息"
                });
            });
        });
        _hubConnection.On<string, string, string>("ReceivePrivateMessage", (sourceUser, targetUser, message) =>
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new Message()
                {
                    Source = sourceUser,
                    Target = targetUser,
                    Content = message,
                    Description = "远程接收到的消息"
                });
            });
        });
        await ConnectHub();
    }

    [RelayCommand]
    public void Send(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;
        if (string.IsNullOrWhiteSpace(SourceUser)) return;

        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            Messages.Add(new Message()
            {
                Content = message,
                Description = "ERROR DATE"
            });
            return;
        }

        if (string.IsNullOrWhiteSpace(TargetUser))
        {
            _hubConnection.SendAsync("SendMessage", SourceUser, message);
            Messages.Add(new Message()
            {
                Source = SourceUser,
                Target = "All",
                Content = message
            });
        }
        else
        {
            _hubConnection.SendAsync("SendTargetMessage", SourceUser, TargetUser, message);
            Messages.Add(new Message()
            {
                Source = SourceUser,
                Target = TargetUser,
                Content = message
            });

        }

        InputMessage = string.Empty;

    }

    [RelayCommand]
    public async Task ConnectHub()
    {
        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            try
            {
                await _hubConnection.StartAsync();
                Messages.Add(new Message()
                {
                    Content = "Connected to SignalR server."
                });
            }
            catch (Exception ex)
            {
                Messages.Add(new()
                {
                    Content = $"Error connecting to SignalR server.: {ex.Message}"
                });
            }
        }
    }

    [RelayCommand]
    public void AddFriend()
    {
        Friends.Add(new() { Name = NewFriendName });
        NewFriendName = string.Empty;
    }
}

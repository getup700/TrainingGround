using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using WpfApp.Communication.Client1.Models;
using WpfApp.Communication.Client1.Services;

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
        Me.Name = "stark";
    }

    public ObservableCollection<User> Friends { get; set; } = [];

    [ObservableProperty]
    User _currentChatUser = new();

    [ObservableProperty]
    User _me = new();

    public ObservableCollection<Message> Messages { get; set; } = [];

    [ObservableProperty]
    string _inputMessage;

    [ObservableProperty]
    string _newFriendName;

    [ObservableProperty]
    HubConnectionState _connState;


    private async Task InitializeHubConnection()
    {
        _hubConnection.On<string, string>("ReceiveStringMessage", (user, message) =>
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new Message()
                {
                    Sender = user,
                    Content = message,
                    Description = "远程接收到的消息"
                });
            });
        });
        _hubConnection.On<string, string, string>("ReceivePrivateStringMessage", (sourceUser, targetUser, message) =>
        {
            App.Current.Dispatcher.Invoke(async () =>
            {
                var newMessage = new Message()
                {
                    Sender = sourceUser,
                    Receiver = targetUser,
                    Content = message,
                    Description = "远程接收到的消息"
                };
                Messages.Add(newMessage);
            });
        });
        _hubConnection.On<Message>("ReceiveMessage", (message) =>
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(message);
            });
        });
        await ConnectHub();
    }

    [RelayCommand]
    public void Send()
    {
        if (string.IsNullOrWhiteSpace(InputMessage)) return;
        if (string.IsNullOrWhiteSpace(Me.Name)) return;

        var newMessage = new Message()
        {
            Sender = Me.Name,
            Content = InputMessage
        };

        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            newMessage.Description = "消息未发出";
            Messages.Add(newMessage);
            return;
        }

        if (string.IsNullOrWhiteSpace(CurrentChatUser?.Name))
        {
            newMessage.Receiver = "All";

            _hubConnection.SendAsync("SendMessage", newMessage);
            Messages.Add(newMessage);
        }
        else
        {
            newMessage.Receiver = CurrentChatUser.Name;
            _hubConnection.SendAsync("SendPrivateMessage", newMessage);
            Messages.Add(newMessage);

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
        else
        {
            await _hubConnection.StopAsync();
            Messages.Add(new Message()
            {
                Content = "Disconnected from SignalR server."
            });
        }
        ConnState = _hubConnection.State;
    }

    [RelayCommand]
    public void AddFriend()
    {
        Friends.Add(new() { Name = NewFriendName });
        NewFriendName = string.Empty;
    }
}

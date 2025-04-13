using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;

namespace WpfApp.Communication.Client1;

internal partial class MainWindowViewModel:ObservableObject
{
    private HubConnection _hubConnection;

    public MainWindowViewModel(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
        InitializeHubConnection();
    }

    public ObservableCollection<Message> Messages { get; set; } = [];

    private async Task InitializeHubConnection()
    {
        _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
             App.Current.Dispatcher.Invoke(() =>
              {
                  Messages.Add(new Message(user, message));
              });
        });

        try
        {
            await _hubConnection.StartAsync();
            Messages.Add(new Message("Connected to SignalR server."));
        }
        catch (Exception ex)
        {
            Messages.Add(new($"Error connecting to server: {ex.Message}"));
        }
    }

    [RelayCommand]
    public void Send(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            Messages.Add(new Message(message,"error data"));
            return;
        }

        Messages.Add(new Message(message,"from WPF client2"));
        _hubConnection.SendAsync("SendMessage", "WPF Client2", message);
    }
}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.SignalR.Client;

namespace WpfApp.Communication;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private HubConnection hubConnection;
    public MainWindow()
    {
        InitializeComponent();
        InitializeSignalR();
    }
    private async void InitializeSignalR()
    {
        this.ListBox.Items.Add(new Message("gogogo"));
        hubConnection = new HubConnectionBuilder()
           .WithUrl("http://localhost:5000/notificationHub")
           .WithUrl("http://localhost:7109/notificationHub")
           .WithUrl("http://localhost:5120/notificationHub")
           .Build();

        hubConnection.On<string>("DDD", (message) =>
        {
            this.Dispatcher.Invoke(() =>
            {
                ListBox.Items.Add(new Message($"Received notification: {message}"));
            });

        });
        hubConnection.On<string, string>("boardcast", (name, message) =>
        {

            this.Dispatcher.Invoke(() =>
            {
                ListBox.Items.Add(new Message($"{name}:{message}"));
            });
        });

        try
        {
            await hubConnection.StartAsync();
            ListBox.Items.Add(new Message("Connected to SignalR server."));
        }
        catch (Exception ex)
        {
            ListBox.Items.Add(new Message($"Connection failed: {ex.Message}"));
        }
    }

    private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (hubConnection != null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
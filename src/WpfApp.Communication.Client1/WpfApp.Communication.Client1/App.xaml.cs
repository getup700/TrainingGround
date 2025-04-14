using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApp.Communication.Client1.ViewModels;
using WpfApp.Communication.Client1.Views;

namespace WpfApp.Communication.Client1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var builder = Host.CreateApplicationBuilder();

        var hubBuilder = new HubConnectionBuilder()
              .WithUrl("http://localhost:5000/chatHub")
              .WithUrl("http://localhost:5299/chatHub")
              .Build();
        builder.Services.AddSingleton(hubBuilder);
        builder.Services.AddSingleton<MainWindowViewModel>();
        builder.Services.AddSingleton<MainWindow>();

        var _host = builder.Build();
        _host.Start();

        var view = _host.Services.GetRequiredService<MainWindow>();
        var vm = _host.Services.GetRequiredService<MainWindowViewModel>();
        view.DataContext = vm;
        view.ShowDialog();
    }
}


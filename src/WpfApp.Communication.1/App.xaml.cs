using System;
using System.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WpfApp.Communication._1.Hubs;

namespace WpfApp.Communication._1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var d = Host.CreateDefaultBuilder()
            
            .Build();
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddSignalRCore();

        builder.WebHost.UseKestrel()
                      .UseUrls("http://localhost:5000");

        var app = builder.Build();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<ChatHub>("/chatHub");
        });

        var host = new HostBuilder()
          .ConfigureServices(services =>
          {
              services.AddSingleton(app.Services.GetRequiredService<ChatHub>());
          })
          .Build();

        host.RunAsync();
        app.Run();
    }
}

using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Events;

namespace WpfApp1.Workers
{
    internal class ReceiveWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            WeakReferenceMessenger.Default.Register<MessageEvent>(this, (o, e) =>
            {
                WeakReferenceMessenger.Default.Send(new ValueChangedMessage<string>($"666666{DateTime.Now}"));
            });
            return Task.CompletedTask;
        }
    }
}

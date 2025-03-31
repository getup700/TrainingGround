using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Events;

namespace WpfApp1.Workers;


internal class SendWorker : BackgroundService
{
    private readonly IEventAggregator _eventAggregator;

    public SendWorker(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var periodTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        while (await periodTimer.WaitForNextTickAsync(stoppingToken))
        {
            _eventAggregator.GetEvent<MessageEvent>().Publish();
            Debug.WriteLine("sendworker send a message");
            WeakReferenceMessenger.Default.Send(new MessageEvent());
        }
    }
}

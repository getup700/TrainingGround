using ConsoleApp1.Events;
using Microsoft.Extensions.Hosting;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Workers;

internal class SendWorder : BackgroundService
{
    private readonly IEventAggregator _eventAggregator;

    public SendWorder(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (DateTime.Now.Second % 2 == 0)
        {
            _eventAggregator.GetEvent<MessageEvent>().Publish();
        }
        return Task.CompletedTask;
    }
}

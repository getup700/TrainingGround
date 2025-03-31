using ConsoleApp1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ViewModels
{
    internal class MainViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MessageEvent>().Subscribe(() =>
            {
                Console.WriteLine("MainViewModel received a message");
            });
        }
    }
}

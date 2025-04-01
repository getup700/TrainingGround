using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Events;

namespace WpfApp1.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IServiceProvider _serviceProvider;

        public MainWindowViewModel(IEventAggregator eventAggregator, IServiceProvider serviceProvider)
        {
            _eventAggregator = eventAggregator;
            _serviceProvider = serviceProvider;

            _eventAggregator.GetEvent<MessageEvent>().Subscribe(() =>
            {
                Message = $"我收到了消息{DateTime.Now}";
            });
            //WeakReferenceMessenger.Default.Register<MessageEvent>(this, (o, e) =>
            //{
            //    Message = $"我收到了消息{DateTime.Now}";
            //});

            WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, (o, e) =>
            {
                Message = e.Value;
            });
        }

        private string _message = "666";

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _sendCommand;

        public DelegateCommand SendCommand => _sendCommand ??= new DelegateCommand(Send); 

        public void Send()
        {
            _eventAggregator.GetEvent<MessageEvent>().Publish();
        }

    }
}

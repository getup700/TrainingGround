using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModels.Communication;

internal partial class MessageQueueViewModel : ObservableObject
{
    //private MessageQueue _messageQueue = new MessageQueue(@".\private$\MyQueue");
    //private string _path = ".\\private$\\test\\journal$";
    //[ObservableProperty]
    //private string _message = "MessageQueueViewModel";

    //[RelayCommand]
    //public void Send()
    //{
    //    var queue = new MessageQueue(_path);
    //    new Thread(() =>
    //    {
    //        while (true)
    //        {
    //            Thread.Sleep(1);
    //            queue.Send(DateTime.Now);
    //        }
    //    }).Start();


    //}

    //[RelayCommand]
    //public void Receive()
    //{
    //    var queue = new MessageQueue(_path);
    //    new Thread(() =>
    //    {
    //        while (true)
    //        {
    //            try
    //            {

    //                var msg = queue.Receive();
    //                Message = (string)msg.Body;
    //            }
    //            catch (Exception)
    //            {

    //            }
    //        }
    //    }).Start();
    //}
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp.Tcp;

partial class WorkWindowViewModel : ObservableObject
{
    private bool _shouldStop;
    private Thread _thread;

    [ObservableProperty]
    private string _message;

    [RelayCommand]
    public void Stop()
    {
        while (_shouldStop)
        {
            Process();
        }
    }

    [RelayCommand]
    public void Start()
    {
        _thread = new Thread(() =>
        {
            Process();
        });
        _thread.IsBackground = true;
        _thread.Start();
    }


    private async Task Process()
    {
        await Task.Delay(3000);
        //var count = 0;
        //var perodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        //while (await perodicTimer.WaitForNextTickAsync())
        //{
        //    count++;

        //    Message = $"I'm working :{count}";
        //    if (count > 3)
        //    {
        //        break;
        //    }
        //}
        _shouldStop = false;
    }
}


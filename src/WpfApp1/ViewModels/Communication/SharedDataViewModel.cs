using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModels.Communication;

internal partial class SharedDataViewModel : ObservableObject
{
    private static readonly object _lockObject = new object();
    private StringBuilder _builder = new();
    private Mutex _mutex = new();
    private Thread _producerThread;
    private Thread _producerThread2;
    private Thread _consumerThread;

    public SharedDataViewModel()
    {
        _producerThread = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                Numbers.Add(i);
            }
        });
        _consumerThread = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                if (Numbers.Any())
                {
                    Numbers.RemoveAt(0);
                }
            }
        });
        
    }

    [ObservableProperty]
    string _message = "SharedDataViewModel";

    [ObservableProperty]
    string _targetMessage;

    public List<int> Numbers { get; set; } = [1,2,3,4,5,6,7,8,9,10];

    [ObservableProperty]
    int _sum;

    [RelayCommand]
    public void Start()
    {
        var threads = new Thread[100];
        for (int i = 0; i < 100; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    lock (Numbers)
                    {
                        Numbers.Add(j);
                    }
                }
            });
        }
        foreach (var item in threads)
        {
            item.Start();
        }
        foreach (var item in threads)
        {
            item.Join();
        }
        Message = Numbers.Count.ToString();
    }

    [RelayCommand]
    public void Stop()
    {
        _producerThread.Join();
        //_producerThread2.Join();
        _consumerThread.Join();
    }

    [RelayCommand]
    public void Resume()
    {
        _producerThread.Resume();
        _producerThread2.Join();
        _consumerThread.Join();
    }

    private void Produce()
    {
        Message = DateTime.Now.ToString();
    }

    public void Consume()
    {
        TargetMessage = Message;
    }
}

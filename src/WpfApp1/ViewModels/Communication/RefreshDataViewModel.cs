using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Communication;

internal partial class RefreshDataViewModel : ObservableObject
{
    private CancellationTokenSource _tokenSource = new();
    private ManualResetEvent _lock = new(true);
    private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private List<Student> _students = new List<Student>() {
        new Student()  {Id = 1,Name = "omar"},
        new Student()  {Id = 2,Name = "dann"},
        new Student()  {Id = 3,Name = "lily"},
        new Student()  {Id = 4,Name = "func"},
        new Student()  {Id = 5,Name = "func"},
        new Student()  {Id = 6,Name = "func"},
        new Student()  {Id = 7,Name = "func"},
        new Student()  {Id = 8,Name = "func"},
        new Student()  {Id = 9,Name = "func"},
    };


    public async Task PollingAsync()
    {
        await Task.Run(async () =>
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                //_lock.WaitOne();
                Count = _semaphore.CurrentCount;
                await _semaphore.WaitAsync(_tokenSource.Token);
                Count = _semaphore.CurrentCount;
                await Application.Current.Dispatcher.Invoke(async () =>
                {
                    await Refresh();
                    Message = "wait...";
                });
                //_lock.Set();
                Count = _semaphore.CurrentCount;
                _semaphore.Release();
                Count = _semaphore.CurrentCount;
                await Task.Delay(2000);
                await Task.Delay(1);
            }
        }, _tokenSource.Token);
    }

    public ObservableCollection<Student> Students { get; set; } = [];

    [ObservableProperty]
    string _message;

    [ObservableProperty]
    int _count;

    [RelayCommand]
    public async Task Refresh()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Message = "Refresh...";
        });
        Clear();

        foreach (var student in _students)
        {
            Students.Add(student);
            await Task.Delay(300);
        }
        _tokenSource = new();
        Message = "Refresh over";
    }

    [RelayCommand]
    public void Clear()
    {
        Message = "Clear...";
        Students.Clear();
    }

    [RelayCommand]
    public async Task Stop()
    {
        Message = "Stop";
        Count = _semaphore.CurrentCount;
        if (await _semaphore.WaitAsync(TimeSpan.FromSeconds(2)))
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Message = "Polling task is paused.";
            });
        }
        //_lock.Reset();

    }

    [RelayCommand]
    public void Restart()
    {
        Message = "Restart";
        Count = _semaphore.CurrentCount;
        //_tokenSource = new();
        _semaphore.Release();
        Count = _semaphore.CurrentCount;
        PollingAsync();
        //_lock.Set();
    }
}

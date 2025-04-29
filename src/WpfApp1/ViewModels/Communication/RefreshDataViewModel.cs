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


    public RefreshDataViewModel()
    {
        Task.Run(async () =>
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                _lock.WaitOne();
                await Application.Current.Dispatcher.Invoke(async () =>
                {
                    await Refresh();
                    Message = "wait...";
                });
                _lock.Set();
                await Task.Delay(2000);
                await Task.Delay(1);
            }
        });
    }

    public ObservableCollection<Student> Students { get; set; } = [];

    [ObservableProperty]
    string _message;

    [RelayCommand]
    public async Task Refresh()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Message = "Refresh...";
        });
        await Task.Delay(1000);
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
    public void Stop()
    {
        Message = "Stop";
        //_tokenSource?.Cancel();
        _lock.Reset();
    }

    [RelayCommand]
    public void Restart()
    {
        Message = "Restart";
        //_tokenSource.TryReset();
        _lock.Set();
    }
}

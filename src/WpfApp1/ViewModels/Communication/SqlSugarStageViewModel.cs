using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Entities;

namespace WpfApp1.ViewModels.Communication;

internal partial class SqlSugarStageViewModel : ObservableObject
{

    private readonly ISqlSugarClient _db;
    private readonly IServiceProvider _provider;
    public ObservableCollection<ISqlSugarClient> Clients = [];
    private SemaphoreSlim _semaphore = new(1, 1);

    public SqlSugarStageViewModel(ISqlSugarClient db, IServiceProvider provider)
    {
        _db = db;
        _provider = provider;
    }

    public ObservableCollection<Actor> ActorList { get; set; } = [];

    [ObservableProperty]
    int _validConnection;

    [ObservableProperty]
    int _totalConnection;

    [ObservableProperty]
    string _lastState;

    [ObservableProperty]
    string _firstState;

    [ObservableProperty]
    string _state;

    [RelayCommand]
    async Task Refresh()
    {
        var thread = new Thread(() => ValidConnection = (int)Random.Shared.NextInt64());
        //thread.IsBackground = true;
        thread.Start();
        //ValidConnection = await GetCount();
        //TotalConnection = ValidConnection + 1;

        //ActorList.Clear();
        //_db.Queryable<Actor>()
        //    .Take(100)
        //    .ToList()
        //    .ForEach(x => ActorList.Add(x));
        //Task.Run(async () =>
        //{
        //    while (true)
        //    {
        //        await _semaphore.WaitAsync();
        //        var db = _provider.GetService<ISqlSugarClient>();
        //        Clients.Add(db);
        //        _semaphore.Release();
        //        await Task.Delay(1);
        //    }
        //});
        //Task.Run(async () =>
        //{
        //    while (true)
        //    {
        //        await _semaphore.WaitAsync();
        //        TotalConnection = Clients.Count;
        //        ValidConnection = Clients
        //            .Where(x => x.Ado.Connection.State != System.Data.ConnectionState.Open)
        //            .Count();
        //        LastState = Clients.Last().Ado.Connection.State.ToString();
        //        _semaphore.Release();
        //        await Task.Delay(1);
        //    }
        //});
    }


    [RelayCommand]
    void Hello(Actor actor)
    {
        MessageBox.Show(actor.FirstName);
    }

    [RelayCommand]
    void ReadSugar()
    {
        //FirstState = _db.Ado.Connection.State.ToString();
        //_db.Queryable<Actor>()
        //    .Where(x => !x.FirstName.Contains("1"))
        //    .Select(x => x.FirstName)
        //    .ToList()
        //    .ForEach(x =>
        //    {
        //        State = _db.Ado.Connection.State.ToString();
        //    });
        //LastState = _db.Ado.Connection.State.ToString();


    }

    public Task<List<Actor>> GetActorsAsync()
    {
        return _db.Queryable<Actor>()
            .Where(x => !x.FirstName.Contains("1"))
            .ToListAsync();
    }


    [RelayCommand]
    async Task Update()
    {
        var actors = _db.Queryable<Actor>().Where(x => x.Id < 50).ToList();
        foreach (var item in actors)
        {
            item.FirstName += "1";
            await Task.Delay(200);
            await _db.Updateable<Actor>(item).ExecuteCommandAsync();
        }
        Refresh();
    }


    [RelayCommand]
    async Task Update1()
    {
        //var _db = _provider.GetRequiredService<ISqlSugarClient>();
        var actors = _db.Queryable<Actor>().Where(x => x.Id < 50).ToList();
        foreach (var item in actors)
        {
            item.FirstName += "1";
            await Task.Delay(200);
            await _db.Updateable<Actor>(item).ExecuteCommandAsync();
        }
        Refresh();
    }

    [RelayCommand]
    async Task SubstringName()
    {
        var actors = _db.Queryable<Actor>()
            .Where(x => x.FirstName.EndsWith("1"))
            .ToList();
        foreach (var item in actors)
        {
            item.FirstName = item.FirstName.Remove(item.FirstName.Length - 1, 1);
            await _db.Updateable<Actor>(item).ExecuteCommandAsync();
        }
        Refresh();
    }

    [RelayCommand]
    void Clear()
    {
        ActorList.Clear();
    }

    public async Task<int> GetCount()
    {
        var result = await Task.Run(() => (int)Random.Shared.NextInt64());
        //return Task.FromResult((int)Random.Shared.NextInt64());
        return result;
    }
}

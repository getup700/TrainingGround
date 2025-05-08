using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;
using WpfApp1.Services;

namespace WpfApp1.ViewModels.Communication;

internal partial class EFCoreViewModel : ObservableObject
{
    private readonly MySqlDbContext _db;

    public EFCoreViewModel(MySqlDbContext db)
    {
        _db = db;
    }

    public ObservableCollection<Actor> ActorList { get; set; } = [];


    [RelayCommand]
    void Refresh()
    {
        ActorList.Clear();
        _db.Actors
            .Take(100)
            .ToList()
            .ForEach(x => ActorList.Add(x));
    }

    [RelayCommand]
    async Task Update()
    {
        var actors = _db.Actors.Where(x => x.Id < 50).ToList();
        foreach (var item in actors)
        {
            item.FirstName += "1";
            await Task.Delay(200);
            await _db.SaveChangesAsync();
        }
        Refresh();
    }

    [RelayCommand]
    async Task Update1()
    {
        var actors = _db.Actors.Where(x => x.Id < 50).ToList();
        foreach (var item in actors)
        {
            item.FirstName += "1";
            await Task.Delay(200);
            await _db.SaveChangesAsync();
        }
        Refresh();
    }

    [RelayCommand]
    async Task SubstringName()
    {
        
        var actors = _db.Actors
            .Where(x => x.FirstName.EndsWith("1"))
            .ToList();
        foreach (var item in actors)
        {
            item.FirstName = item.FirstName.Remove(item.FirstName.Length - 1, 1);
            _db.Update(item);
        }
        await _db.SaveChangesAsync();
        Refresh();
    }
}

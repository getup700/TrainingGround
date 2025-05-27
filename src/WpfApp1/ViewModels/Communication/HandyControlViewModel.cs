using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels.Communication;

internal partial class HandyControlViewModel:ObservableObject
{
    [RelayCommand]
    public void Show()
    {
        Task.Run(() =>
        {
            Growl.Info("ddddd","token"); 
        });

        var th = new Thread(() =>
        {
            Growl.InfoGlobal("dfadfasd");
        });
        th.Start();
    }

    [RelayCommand]
    public void Success()
    {
        Growl.Success("Success", "Success");
    }

    [RelayCommand]
    public void Info()
    {
        Growl.Info("Info", "Success");
    }

    [RelayCommand]
    public void Error()
    {
        Growl.Error("error", "Error");
    }

    [RelayCommand]
    public void Warning()
    {
        Growl.Warning("Warning", "Error");
    }

    [RelayCommand]
    public void Fatal()
    {
        Growl.Fatal("Fatal", "Error");
    }

    [RelayCommand]
    public void Ask()
    {
        Growl.Ask("Ask", arg=> !arg, "Error");
    }

}

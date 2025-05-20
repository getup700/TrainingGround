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
}

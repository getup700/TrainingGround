using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Utils;
using WpfApp1.Views;

namespace WpfApp1.ViewModels.Communication;

internal partial class HandyControlViewModel:ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public HandyControlViewModel(IServiceProvider serviceProvider,MainWindow main)
    {
        _serviceProvider = serviceProvider;
        var mian = main;
    }

    [RelayCommand]
    public void Show()
    {
        Task.Run(() =>
        {
            Growl.InfoGlobal("ddddd"); 
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
        Growl.SuccessGlobal("Success");
        //ToolUtil.OpenKeyBoardFun();

        LanguageUtil.SwitchInputLanguage("0419");
    }

    [RelayCommand]
    public void Info()
    {
        Growl.InfoGlobal("Info");
    }

    [RelayCommand]
    public void Error()
    {
        var view = _serviceProvider.GetService<MainWindowViewModel>();
        Growl.ErrorGlobal("error");
    }

    [RelayCommand]
    public void Warning()
    {
        Growl.WarningGlobal("Warning");
    }

    [RelayCommand]
    public void Fatal()
    {
        Growl.FatalGlobal("Fatal");
    }

    [RelayCommand]
    public void Ask()
    {
        Growl.AskGlobal("Ask", arg=> !arg);
    }

}

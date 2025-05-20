using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Pipes;
using System.IO;
using WpfApp1.Services;

namespace WpfApp1.ViewModels.Communication;

internal partial class PipeStreamViewModel : ObservableObject
{

    private readonly IConsoleStrategy _helloStrategy;
    private readonly IConsoleStrategy _hiStrategy;

    //public PipeStreamViewModel([FromKeyedServices("hello")]IConsoleStrategy helloStrategy,
    //    [FromKeyedServices("hi")]IConsoleStrategy hiStrategy)
    //{
    //    _helloStrategy = helloStrategy;
    //    _hiStrategy = hiStrategy;
    //}

    public PipeStreamViewModel()
    {
        //g了
        _helloStrategy = App.Provider.Resolve<IConsoleStrategy>("hello");
        _hiStrategy = App.Provider.Resolve<IConsoleStrategy>("hi");

    }


    [ObservableProperty]
    private string _message = "PipeStreamViewModel";

    [RelayCommand]
    public void Hello()
    {
        Message = _helloStrategy.Console();
    }

    [RelayCommand]
    public void Hi()
    {
        Message = _hiStrategy.Console();
    }

}

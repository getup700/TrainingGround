using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Events;

namespace WpfApp1.ViewModels;

internal partial class MainWindowViewModel : ObservableObject
{
    private readonly IRegionManager _regionManager;

    public MainWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    [RelayCommand]
    public void Route(string key)
    {
        try
        {
            _regionManager.RequestNavigate("MainRegion", key);
        }
        catch (Exception e)
        {
            //
        }
    }
}

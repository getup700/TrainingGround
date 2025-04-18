using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels.Communication;

internal partial class DelegateViewModel : ObservableObject
{
    [ObservableProperty]
    private string _message = "DelegateViewModel";

    public ObservableCollection<string> Messages { get; set; } = [];

    [RelayCommand]
    public void Add()
    {
        Messages.Add(DateTime.Now.ToString());
    }
}

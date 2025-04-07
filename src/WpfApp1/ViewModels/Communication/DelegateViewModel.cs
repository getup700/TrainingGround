using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels.Communication;

internal partial class DelegateViewModel:ObservableObject
{
    [ObservableProperty]
    private string _message = "DelegateViewModel";

}

using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels.Communication;

internal partial class PipeStreamViewModel : ObservableObject
{
    [ObservableProperty]
    private string _message = "PipeStreamViewModel";
}

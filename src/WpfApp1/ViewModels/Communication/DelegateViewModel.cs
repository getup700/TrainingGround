using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using WpfApp1.Views;

namespace WpfApp1.ViewModels.Communication;

internal partial class DelegateViewModel : ObservableObject
{
    private readonly IServiceProvider serviceProvider;

    public DelegateViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private string _message = "DelegateViewModel";

    public ObservableCollection<string> Messages { get; set; } = [];

    [RelayCommand]
    public void Add()
    {
        Messages.Add(DateTime.Now.ToString());
        var view = serviceProvider.GetRequiredService<MainWindow>();
    }
}

using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp.Communication.Client1.Models;

public partial class User:ObservableObject
{
    [ObservableProperty]
    string _name;

    [ObservableProperty]
    string _description;

    [ObservableProperty]
    bool _isOnLine;
}

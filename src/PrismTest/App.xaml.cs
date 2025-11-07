using System.Configuration;
using System.Data;
using System.Windows;
using Prism.DryIoc;
using Prism.Mvvm;
using PrismTest.ViewModels;
using PrismTest.Views;

namespace PrismTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CommonView, ShowViewModel>("Show");
            containerRegistry.RegisterDialog<CommonView, EditViewModel>("Edit");

            ViewModelLocationProvider.Register(typeof(CommonView).ToString(), typeof(ShowViewModel));
            ViewModelLocationProvider.Register(typeof(CommonView).ToString(), typeof(EditViewModel));
        }
    }

}

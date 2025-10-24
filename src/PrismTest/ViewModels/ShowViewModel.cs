using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    class ShowViewModel:ViewModelBase,INavigationAware
    {
        public ShowViewModel():base()
        {
            Title = "Show";
            ShowCommand = new DelegateCommand(Show);
        }

        public ICommand ShowCommand { get; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
    
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        private void Show()
        {
            MessageBox.Show(Title);
        }
    }
}

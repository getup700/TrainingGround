using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    class MainWindowViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            ShowCommand = new DelegateCommand(Show);
            EditCommand = new DelegateCommand(Edit);
        }

        public ICommand ShowCommand { get; }
        private void Show()
        {
            _regionManager.RequestNavigate("mainPage", "Show");
        }

        public ICommand EditCommand { get; }
        private void Edit()
        {
            _dialogService.Show("Edit");
        }
    }
}

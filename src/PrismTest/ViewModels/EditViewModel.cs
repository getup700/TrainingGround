using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    class EditViewModel : ViewModelBase, IDialogAware
    {
        public EditViewModel() : base()
        {
            Title = "Edit";
            EditCommand = new DelegateCommand(Edit);
        }

        public ICommand EditCommand { get; }

        public DialogCloseListener RequestClose { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        private void Edit()
        {
            MessageBox.Show(Title);
        }
    }
}

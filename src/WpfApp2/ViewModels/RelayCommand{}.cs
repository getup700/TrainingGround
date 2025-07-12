using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2.ViewModels
{
    class RelayCommand<T>:ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<T> action;
        private Func<object, bool>? func;

        public RelayCommand(Action<T> execute, Func<object, bool> canExecute = null)
        {
            action = execute;
            func = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (func == null)
            {
                return true;
            }
            return func.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            action?.Invoke((T)parameter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    class ViewModelBase:BindableBase
    {
        public ViewModelBase()
        {
			GoCommand = new DelegateCommand(Go);
        }

        private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value;RaisePropertyChanged(); }
		}

		public ICommand GoCommand { get; }
		private void Go()
		{
			MessageBox.Show(Title);
		}
	}
}

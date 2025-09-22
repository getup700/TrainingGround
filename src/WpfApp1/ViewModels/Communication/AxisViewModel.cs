using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels.Communication
{
    internal class AxisViewModel:BindableBase
    {
		private double _x;

		public double X
		{
			get { return _x; }
			set { _x = value; RaisePropertyChanged(); }
		}

		private double _y;

		public double Y
		{
			get { return _y; }
			set { _y = value; RaisePropertyChanged(); }
        }

		private double _z;

		public double Z
		{
			get { return _z; }
			set { _z = value; RaisePropertyChanged(); }
		}


	}
}

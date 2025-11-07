using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace WpfApp1.ViewModels.Communication
{
    internal partial class AxisViewModel : ObservableObject
    {
        private double _X1Hor;

        public double X1Hor
        {
            get { return _X1Hor; }
            set { _X1Hor = value; OnPropertyChanged(); }
        }

        private double _X1Ver;

        public double X1Ver
        {
            get { return _X1Ver; }
            set { _X1Ver = value; OnPropertyChanged(); }
        }

        private double _Y1Hor;

        public double Y1Hor
        {
            get { return _Y1Hor; }
            set { _Y1Hor = value; OnPropertyChanged(); }
        }

        private double _Y1Ver;

        public double Y1Ver
        {
            get { return _Y1Ver; }
            set { _Y1Ver = value; OnPropertyChanged(); }
        }

        private double _ZHor;

        public double ZHor
        {
            get { return _ZHor; }
            set { _ZHor = value; OnPropertyChanged(); }
        }

        private double _ZVer;

        public double ZVer
        {
            get { return _ZVer; }
            set { _ZVer = value; OnPropertyChanged(); }
        }


        private double _x, _y, _z;
        public double X
        {
            get => _x; set
            {
                _x = value;
                OnPropertyChanged();
                X1Hor = -_x * 0.8;
                X1Ver = _x * 0.8;
            }
        }

        public double Y
        {
            get => _y; set
            {
                _y = value;
                OnPropertyChanged();
                //Y1Hor = _y ;
                Y1Ver = _y;
            }
        }

        public double Z
        {
            get => _z; set
            {
                _z = value;
                OnPropertyChanged();
                ZHor = _z * 0.6;
                ZVer = _z * 0.6;
            }
        }



    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models.Axis2;

namespace WpfApp1.ViewModels.Communication
{
    internal partial class Axis2ViewModel:ObservableObject
    {
        private readonly ArmParameters _p;

        public Axis2ViewModel() : this(new ArmParameters()) { }
        public Axis2ViewModel(ArmParameters p) => _p = p;

        [NotifyPropertyChangedFor(nameof(X1Hor))]
        [NotifyPropertyChangedFor(nameof(X1Ver))]
        [ObservableProperty] 
        private double _x = 100;

        [NotifyPropertyChangedFor(nameof(Y1Hor))]
        [NotifyPropertyChangedFor(nameof(Y1Ver))]
        [ObservableProperty] 
        private double _y = 50;

        [NotifyPropertyChangedFor(nameof(ZHor))]
        [NotifyPropertyChangedFor(nameof(ZVer))]
        [ObservableProperty] 
        private double _z = 80;

      


        /* 只读属性，XAML 直接绑 */
        public double X1Hor => -X * _p.ScaleX;
        public double X1Ver => X * _p.ScaleX;
        public double Y1Hor => Y * _p.ScaleX;
        public double Y1Ver => Y;
        public double ZHor => Z * _p.ScaleZ;
        public double ZVer => -Z * _p.ScaleZ;
    }
}

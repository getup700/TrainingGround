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
        private double _x, _y, _z;
        public double X { get => _x; set { _x = value; OnPropertyChanged(); UpdateY(); } }
        public double Y { get => _y; set { _y = value; OnPropertyChanged(); UpdateZ(); } }
        public double Z { get => _z; set { _z = value; OnPropertyChanged(); } }

        // 级联：Y 随 X 移动，Z 随 Y 移动
        private void UpdateY() => Y = X * 0.8;   // 举例线性关系
        private void UpdateZ() => Z = Y * 0.6;

        public Transform3D YTransform =>
            new TranslateTransform3D(X / 100 * 4 - 2, 0, 0);   // 映射到 3D 坐标
        public Transform3D ZTransform =>
            new TranslateTransform3D(Y / 100 * 3 - 1.5, 0, 0);


    }
}

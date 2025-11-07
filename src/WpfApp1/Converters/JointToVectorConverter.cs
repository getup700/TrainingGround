using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    internal class JointToVectorConverter:IValueConverter
    { 
        /* 正等轴测：X 轴向右下，Y 轴向左下，Z 轴向上
       比例系数可配，支持任意“轴间角” */
        public object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v == null) return 0d;
            var len = System.Convert.ToDouble(v);
            var param = p as string ?? "X";
            return param switch
            {
                "X" => len * 0.894,   // cos(arctan(0.5))
                "Y" => -len * 0.894,
                _ => -len * 0.447   // sin(arctan(0.5))
            };
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
            => Binding.DoNothing;
    }
}

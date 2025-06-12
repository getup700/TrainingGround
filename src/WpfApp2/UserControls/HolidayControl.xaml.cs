using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.UserControls
{
    /// <summary>
    /// HolidayControl.xaml 的交互逻辑
    /// </summary>
    public partial class HolidayControl : UserControl
    {
        public HolidayControl()
        {
            InitializeComponent();
        }



        public string Holiday
        {
            get { return (string)GetValue(HolidayProperty); }
            set { SetValue(HolidayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Holiday.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HolidayProperty =
            DependencyProperty.Register("Holiday", typeof(string), typeof(HolidayControl), new PropertyMetadata(0));









    }
}

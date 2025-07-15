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
using WpfApp1.Utils;

namespace WpfApp1.Views.Communication
{
    /// <summary>
    /// SharedDataView.xaml 的交互逻辑
    /// </summary>
    public partial class SharedDataView : UserControl
    {
        public SharedDataView()
        {
            InitializeComponent();

            BindUtil.SetBinding(this.head, "string1");
            BindUtil.SetBinding(this.middle, "string2");
            BindUtil.SetBinding(this.tail, "string3");

            this.Loaded += SharedDataView_Loaded;
            this.updateBtn.Click += UpdateBtn_Click;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources["string3"] = $"不一般的字符串{DateTime.Now}";
        }

        private async void SharedDataView_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            Application.Current.Resources["string3"] = "不一般的字符串";
        }
    }
}

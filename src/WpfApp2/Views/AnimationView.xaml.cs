using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp2.Views
{
    /// <summary>
    /// AnimationView.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationView : UserControl
    {
        public AnimationView()
        {
            InitializeComponent();
            this.Loaded += AnimationView_Loaded;
        }

        private void AnimationView_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("animation loaded");
        }

        ~AnimationView()
        {
            Debug.WriteLine("AnimationView 正在被释放内存");
        }
    }
}

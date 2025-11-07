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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimation.Views
{
    /// <summary>
    /// LinearAnimationView.xaml 的交互逻辑
    /// </summary>
    public partial class LinearAnimationView : UserControl
    {
        public LinearAnimationView()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock tb)
            {
                var doubleAnm = new DoubleAnimation();
                doubleAnm.From = 100;
                doubleAnm.To = 300;
                doubleAnm.Duration = TimeSpan.FromSeconds(3);

                //tb.BeginAnimation(WidthProperty, doubleAnm);


                var doubleAnm1 = new DoubleAnimation();
                doubleAnm1.To = 100;
                doubleAnm1.To = 200;
                doubleAnm1.Duration = TimeSpan.FromSeconds(3);

                //tb.BeginAnimation(HeightProperty, doubleAnm);

                var sb = new Storyboard();
                sb.Children.Add(doubleAnm);
                sb.Children.Add(doubleAnm1);

                Storyboard.SetTarget(doubleAnm, tb);
                Storyboard.SetTargetProperty(doubleAnm, new PropertyPath("Width"));

                Storyboard.SetTarget(doubleAnm1, tb);
                Storyboard.SetTargetProperty(doubleAnm1, new PropertyPath("Height"));

                sb.Begin();
            }

        }
    }
}

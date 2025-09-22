using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp2.Views
{
    /// <summary>
    /// AnimationListBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationListBoxView : UserControl
    {
        public AnimationListBoxView()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PlayEnterAnimations();
        }

        private void PlayEnterAnimations()
        {
            int i = 0;
            foreach (var item in MyListBox.Items)
            {
                if (MyListBox.ItemContainerGenerator.ContainerFromItem(item) is ListBoxItem lbi)
                {
                    // 确保有 RenderTransform
                    var trans = new TranslateTransform(100, 0);
                    lbi.RenderTransform = trans;
                    lbi.Opacity = 0;

                    var delay = TimeSpan.FromMilliseconds(100 * i++);

                    // 横向滑入
                    var slideAnim = new DoubleAnimation(100, 0, TimeSpan.FromMilliseconds(300))
                    {
                        BeginTime = delay,
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    trans.BeginAnimation(TranslateTransform.XProperty, slideAnim);

                    // 渐显
                    var fadeAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200))
                    {
                        BeginTime = delay
                    };
                    lbi.BeginAnimation(UIElement.OpacityProperty, fadeAnim);
                }
            }
        }
    }
}

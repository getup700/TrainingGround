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
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class ComboBoxView : UserControl
    {
        public ComboBoxView()
        {
            InitializeComponent();
            this.ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            this.button.Click += Button_Click;
            this.stackPanel.Loaded += StackPanel_Loaded;
            this.Loaded += ComboBoxView_Loaded;
        }

        private void ComboBoxView_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("comboBox loaded");
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ComboBox.SelectedIndex = ComboBox.SelectedIndex == 1 ? 0 : 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isUser = IsUserTriggeredSelection((ComboBox)sender);
            var source = isUser ? "用户" : "数据";
            Debug.WriteLine($"{source}修改了选中项");
        }


        private static bool IsUserTriggeredSelection(ComboBox comboBox)
        {
            // 检查焦点是否在ComboBox或其文本框上
            if (Keyboard.FocusedElement == comboBox)
                return true;

            // 检查焦点是否在ComboBox的文本框上（对于可编辑的ComboBox）
            if (comboBox.IsEditable && Keyboard.FocusedElement is TextBox textBox)
            {
                DependencyObject parent = textBox.Parent;
                while (parent != null)
                {
                    if (parent == comboBox)
                        return true;
                    parent = VisualTreeHelper.GetParent(parent);
                }
            }

            // 检查是否通过鼠标点击触发
            if (Mouse.LeftButton == MouseButtonState.Released ||
                Mouse.RightButton == MouseButtonState.Released)
            {
                // 鼠标点击通常会导致ComboBox获得焦点
                if (comboBox.IsKeyboardFocusWithin)
                    return true;
            }

            return false;
        }
    }
}

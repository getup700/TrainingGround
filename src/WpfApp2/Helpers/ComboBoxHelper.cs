using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2.Helpers
{
    public static class ComboBoxHelper
    {
        // 定义附加属性，用于标记是否为用户操作
        public static readonly DependencyProperty IsUserInitiatedProperty =
            DependencyProperty.RegisterAttached(
                "IsUserInitiated",
                typeof(bool),
                typeof(ComboBoxHelper),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static bool GetIsUserInitiated(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUserInitiatedProperty);
        }

        public static void SetIsUserInitiated(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUserInitiatedProperty, value);
        }

        // 定义附加属性，用于绑定选择改变的命令
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached(
                "SelectionChangedCommand",
                typeof(ICommand),
                typeof(ComboBoxHelper),
                new PropertyMetadata(null, OnSelectionChangedCommandPropertyChanged));

        public static ICommand GetSelectionChangedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectionChangedCommandProperty);
        }

        public static void SetSelectionChangedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectionChangedCommandProperty, value);
        }

        private static void OnSelectionChangedCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComboBox comboBox)
            {
                // 移除旧事件处理程序
                comboBox.SelectionChanged -= ComboBox_SelectionChanged;

                if (e.NewValue != null)
                {
                    // 添加新事件处理程序
                    comboBox.SelectionChanged += ComboBox_SelectionChanged;
                }
            }
        }

        private static void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                // 检查是否为用户发起的选择更改
                bool isUserInitiated = e.OriginalSource == comboBox &&
                                       (Keyboard.FocusedElement == comboBox ||
                                        Keyboard.FocusedElement is TextBox textBox &&
                                        VisualTreeHelper.GetParent(textBox) == comboBox);

                // 设置附加属性值
                SetIsUserInitiated(comboBox, isUserInitiated);

                // 获取并执行命令
                ICommand command = GetSelectionChangedCommand(comboBox);
                if (command != null && command.CanExecute(isUserInitiated))
                {
                    command.Execute(isUserInitiated);
                }
            }
        }
    }
}

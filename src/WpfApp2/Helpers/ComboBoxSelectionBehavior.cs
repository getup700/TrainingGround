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
    public class ComboBoxSelectionBehavior
    {
        // 定义附加属性，用于绑定选择更改命令
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached(
                "SelectionChangedCommand",
                typeof(ICommand),
                typeof(ComboBoxSelectionBehavior),
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
                bool isUserInitiated = IsUserTriggeredSelection(comboBox);

                // 获取并执行命令，传递用户操作标志
                ICommand command = GetSelectionChangedCommand(comboBox);
                if (command != null && command.CanExecute(isUserInitiated))
                {
                    command.Execute(isUserInitiated);
                }
            }
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

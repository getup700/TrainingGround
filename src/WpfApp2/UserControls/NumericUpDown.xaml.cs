using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// NumericUpDown.xaml 的交互逻辑
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
            this.upBtn.Click += UpButton_Click;
            this.downBtn.Click += DownButton_Click;
        }



        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericUpDown numeric)
            {
                if (e.NewValue != e.OldValue)
                {
                    var args = new RoutedEventArgs(NumericUpDown.ValueChangedEvent, numeric);
                    numeric.RaiseEvent(args);
                }
            }
        }

        public static readonly RoutedEvent UpClickEvent =
            EventManager.RegisterRoutedEvent("UpClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));

        public event RoutedEventHandler UpClick
        {
            add { AddHandler(UpClickEvent, value); }
            remove { RemoveHandler(UpClickEvent, value); }
        }
        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            Value++;
            RaiseEvent(new RoutedEventArgs(UpClickEvent, sender));
        }

        public static readonly RoutedEvent DownClickEvent =
            EventManager.RegisterRoutedEvent("DownClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
        public event RoutedEventHandler DownClick
        {
            add { AddHandler(DownClickEvent, value); }
            remove { RemoveHandler(DownClickEvent, value); }
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            Value--;
            RaiseEvent(new RoutedEventArgs(DownClickEvent, sender));
        }

        public static readonly RoutedEvent ValueChangedEvent =
            EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
    }
}

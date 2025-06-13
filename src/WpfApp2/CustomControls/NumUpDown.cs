using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.CustomControls
{
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    public class ValueChangedEventArgs : RoutedEventArgs
    {
        private int _value;

        public ValueChangedEventArgs(RoutedEvent id, int num)
        {
            _value = num;
            RoutedEvent = id;
        }

        public int Value
        {
            get { return _value; }
        }
    }

    [TemplatePart(Name = "UpButtonElement", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "DownButtonElement", Type = typeof(RepeatButton))]
    [TemplateVisualState(Name = "Positive", GroupName = "ValueStates")]
    [TemplateVisualState(Name = "Negative", GroupName = "ValueStates")]
    [TemplateVisualState(Name = "Focused", GroupName = "FocusedStates")]
    [TemplateVisualState(Name = "Unfocused", GroupName = "FocusedStates")]
    public class NumUpDown : Control
    {
        static NumUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumUpDown),
                new FrameworkPropertyMetadata(typeof(NumUpDown)));
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(int),
                typeof(NumUpDown),
                new PropertyMetadata(0, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (NumUpDown)d;
            var newValue = (int)e.NewValue;
            ctrl.OnValueChanged(new ValueChangedEventArgs(NumUpDown.ValueChangedEvent, newValue));
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged",
            RoutingStrategy.Bubble,
            typeof(ValueChangedEventHandler),
            typeof(NumUpDown));

        public event ValueChangedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            RaiseEvent(e);
        }

        private void UpdateStates(bool useTransitions)
        {

        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpButtonElement = GetTemplateChild("UpButtonElement") as RepeatButton;
            DownButtonElement = GetTemplateChild("DownButtonElement") as RepeatButton;

            if (UpButtonElement != null)
            {
                UpButtonElement.Click += upButton_Click;
            }
            if (DownButtonElement != null)
            {
                DownButtonElement.Click += downButton_Click;
            }
        }


        private RepeatButton _downButtonElement;

        public RepeatButton DownButtonElement
        {
            get { return _downButtonElement; }
            set
            {
                if (_downButtonElement != null)
                {
                    _downButtonElement.Click -= new RoutedEventHandler(downButton_Click);
                }
                _downButtonElement = value;
                if (_downButtonElement != null)
                {
                    _downButtonElement.Click += new RoutedEventHandler(downButton_Click);
                }
            }
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }


        private RepeatButton _upButtonElement;

        public RepeatButton UpButtonElement
        {
            get { return _upButtonElement; }
            set
            {
                if (_upButtonElement != null)
                {
                    _upButtonElement.Click -= new RoutedEventHandler(upButton_Click);
                }
                _upButtonElement = value;
                if (_upButtonElement != null)
                {
                    _upButtonElement.Click += new RoutedEventHandler(upButton_Click);
                }
            }
        }

        private void upButton_Click(Object sender, RoutedEventArgs e)
        {
            Value++;
        }


    }
}

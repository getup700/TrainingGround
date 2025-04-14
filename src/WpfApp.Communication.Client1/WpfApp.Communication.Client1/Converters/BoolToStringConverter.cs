using System.Globalization;
using System.Windows.Data;

namespace WpfApp.Communication.Client1.Converters
{
    internal class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string paraStr)
            {
                return value;
            }
            var states = paraStr.Split(",");
            if (states.Length < 2)
            {
                return value;
            }
            if (value is not bool indicate)
            {
                return value;
            }
            return indicate ? states[0] : states[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string paraStr)
            {
                return value;
            }
            var states = paraStr.Split(",");
            return states?.Any() != true ? value : states[0] == value.ToString();
        }
    }

}

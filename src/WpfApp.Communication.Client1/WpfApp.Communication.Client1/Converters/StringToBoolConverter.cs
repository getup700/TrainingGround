using System.Globalization;
using System.Windows.Data;

namespace WpfApp.Communication.Client1.Converters
{
    internal class StringToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return false;
            }
            var strings = values.Select(x => x.ToString());
            var first = strings.ElementAt(0);
            var result = true;
            foreach (var item in strings)
            {
                result &= item == first;
            }
            return result;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return [value];
        }
    }

}

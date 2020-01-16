using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WpfDataBase.BaseClasses;

namespace WpfDataBase.View.Converters
{
    public class UserControlVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Parts && parameter is Parts))
            {
                return Binding.DoNothing;
            }

            Parts parts = (Parts)parameter;
            Parts expectedParts = (Parts)value;

            return parts == expectedParts ? Visibility.Visible : Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

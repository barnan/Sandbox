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

            Parts parts = (Parts)value;
            //AdjectiveUserControl adjectiveUserControl = parameter as AdjectiveUserControl;
            //NounUserControl nounUserControl = parameter as NounUserControl;
            //VerbUserControl verbUserControl = parameter as VerbUserControl;

            if (parameter is Parts.Adjective)
            {
                return parts == Parts.Adjective ? Visibility.Visible : Visibility.Collapsed;
            }
            if (parameter is Parts.Noun)
            {
                return parts == Parts.Noun ? Visibility.Visible : Visibility.Collapsed;
            }
            if (parameter is Parts.Verb)
            {
                return parts == Parts.Verb ? Visibility.Visible : Visibility.Collapsed;
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

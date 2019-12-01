using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tshirt.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tappedArgs = value as ItemTappedEventArgs;

            if (tappedArgs == null)
                throw new ArgumentException("Value not an ItemTappedEventArgs");

            return tappedArgs.Item;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

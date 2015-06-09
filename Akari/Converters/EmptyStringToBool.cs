using System;
using System.Windows;
using System.Windows.Data;

namespace Akari.Converters
{
	public class EmptyStringToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !String.IsNullOrEmpty((string)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

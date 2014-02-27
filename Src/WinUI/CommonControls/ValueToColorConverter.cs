using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindEveMagnat.UI.CommonControls
{
	public class ValueToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value == null || !(value is string))
				return DependencyProperty.UnsetValue;

			return value;
		}

		public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
		{
			return new object[] {};
		}
	}
}

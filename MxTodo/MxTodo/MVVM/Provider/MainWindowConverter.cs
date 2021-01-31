using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MxTodo.MVVM.Converter
{
    class MainWindowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (typeof(DateTime) == value?.GetType())
            {
                if ("date".Equals(parameter))
                {
                    return ((DateTime)value).ToString(Config.MxProperty.ClockDateFormat.Value);
                }
                else
                {
                    return ((DateTime)value).ToString(Config.MxProperty.ClockFormat.Value);
                }
            }
            else if ("TodoItemWidth".Equals(parameter))
            {
                return Math.Max(1, (double)value - 4);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

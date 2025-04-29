using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiApp.Converters
{
    class BoleanToTextConverter : IValueConverter
    {
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || value is not bool)
            {
                throw new Exception("null value on IsDone");
            }
            if (Boolean.Parse(value.ToString()))
                return "✔";
            else
                return "❌";
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

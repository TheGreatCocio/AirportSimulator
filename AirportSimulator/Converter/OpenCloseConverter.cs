using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AirportSimulator.Converter
{
    public class OpenCloseConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.Equals(true))
            {
                return "green";
            }
            else
            {
                return "red";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

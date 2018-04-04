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
            if (parameter.Equals("background"))
            {
                if (value.Equals(true))
                {
                    return "LawnGreen";
                }
                else
                {
                    return "Red";
                }
            }
            else if (parameter.Equals("status"))
            {
                if (value.Equals(true))
                {
                    return "Open";
                }
                else
                {
                    return "Closed";
                }
            }
            return null;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

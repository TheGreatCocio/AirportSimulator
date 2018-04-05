using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AirportSimulator.Converter
{
    public class OpenCloseConverter:IValueConverter
    {
        // A Converter to switch color and text based on Terminal/Counter Open/Close State
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // If The parameter send with the caller is "background" it is the background color
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
            // If The parameter send with the caller is "status" it is the status textblock 
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

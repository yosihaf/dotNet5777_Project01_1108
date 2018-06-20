using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UI.Convertors
{
    public class ConvertCompanyOrPerson : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var par = (string)parameter;
            return (par == "Company") ? value : !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var par = (string)parameter;
            return (par == "Company") ? value : !(bool)value;
        }
    }

  
   
}

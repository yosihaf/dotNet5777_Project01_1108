using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using UI.ViewModel;

namespace UI.Convertors
{
    class ConvertViewModeBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var val = ((ViewMode)value);
            var param = ((ViewMode)parameter);
            if (val == param)
                return Visibility.Visible;
            else if (param == ViewMode.EditOrAdd && (val == ViewMode.Edit || val == ViewMode.Add))
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = ((ViewMode)value);
            var param = ((ViewMode)parameter);
            if (val == param)
                return Visibility.Visible;
            else if (param == ViewMode.EditOrAdd && (val == ViewMode.Edit || val == ViewMode.Add))
            {
                return true;
            }
            return false;
        }
    }
}

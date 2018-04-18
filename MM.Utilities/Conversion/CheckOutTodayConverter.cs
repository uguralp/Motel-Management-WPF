using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MM.Utilities
{
    [ValueConversion(typeof(int), typeof(Brush))]
    public class CheckOutTodayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateToCheck = DateTime.Parse(value.ToString());

            if (dateToCheck.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

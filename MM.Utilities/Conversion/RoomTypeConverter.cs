using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MM.Model;

namespace MM.Utilities
{
    [ValueConversion(typeof(int), typeof(Brush))]
    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string roomType = value.ToString();

            if (roomType == RoomTypeName.Suite.ToString())
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

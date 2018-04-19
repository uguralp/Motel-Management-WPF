using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Utilities
{
    public class EnumHelper
    {
        public static T Parse<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}

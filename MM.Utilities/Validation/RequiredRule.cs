using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MM.Utilities
{
    public class RequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToValidate = value as string;

            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Field is required");
            }
            else
            {
                //DateTime orderDate = (DateTime)value;
                return ValidationResult.ValidResult;
            }
        }
    }
}

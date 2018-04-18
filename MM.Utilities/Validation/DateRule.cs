using System;
using System.Globalization;
using System.Windows.Controls;

namespace MM.Utilities
{
    /// <summary>
    /// DateRule
    /// </summary>
    public class DateRule : ValidationRule
    {
        /// <summary>
        /// ValidationResult
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime dateToCheck = (DateTime)value;
            dateToCheck = dateToCheck.Date;
            DateTime currentDate = DateTime.Now.Date;

            if (dateToCheck < currentDate)
            {
                return new ValidationResult(false, "Please select today or after");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

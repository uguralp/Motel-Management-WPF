﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MM.Utilities
{
    /// <summary>
    /// RequiredRule
    /// </summary>
    public class RequiredRule : ValidationRule
    {
        /// <summary>
        /// ValidationResult
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
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

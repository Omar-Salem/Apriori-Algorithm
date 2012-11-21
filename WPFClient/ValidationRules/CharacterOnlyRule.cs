using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WPFClient
{
    public class CharacterOnlyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string input = value as string;
            Regex reg = new Regex("^[a-zA-Z]+$");

            if (input == null || !reg.IsMatch(input))
            {
                return new ValidationResult(false, "Characters only");
            }

            return new ValidationResult(true, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Flashcards2.Views.Validation
{
    public class TextLengthRule : ValidationRule
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public TextLengthRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = (string)value;

            var test = string.IsNullOrWhiteSpace(str);
           if (MinLength == 1 && string.IsNullOrWhiteSpace(str)) return new ValidationResult(false, $"Darf nicht leer sein");

            if (MinLength > 1 && str.Length < MinLength) return new ValidationResult(false, $"Muss aus mindestens {MinLength} Zeichen bestehen.");

            if (MaxLength != 0 && str.Length > MaxLength) return new ValidationResult(false, $"Darf höchstens {MaxLength} Zeichen enthalten.");

            return ValidationResult.ValidResult;
        }
    }
}

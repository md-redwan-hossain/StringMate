using System.ComponentModel.DataAnnotations;
using System.Globalization;
using StringMate.Validation.ValidationRules;

namespace StringMate.Validation.DataAnnotations
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _minLowercase;
        private readonly int _minUppercase;
        private readonly int _minNumbers;
        private readonly int _minSymbols;
        private readonly int _minUniqueChars;

        public StrongPasswordAttribute()
        {
            _minLength = 8;
            _minLowercase = 1;
            _minUppercase = 1;
            _minNumbers = 1;
            _minSymbols = 1;
            _minUniqueChars = 0;
        }

        public StrongPasswordAttribute(int minLength = 8, int minLowercase = 1, int minUppercase = 1,
            int minNumbers = 1, int minSymbols = 1, int minUniqueChars = 0)
        {
            _minLength = minLength;
            _minLowercase = minLowercase;
            _minUppercase = minUppercase;
            _minNumbers = minNumbers;
            _minSymbols = minSymbols;
            _minUniqueChars = minUniqueChars;
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && StrongPasswordValidation.Validate
            (str, _minLength, _minLowercase, _minUppercase, _minNumbers,
                _minSymbols, _minUniqueChars);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid strong password.");
    }
}
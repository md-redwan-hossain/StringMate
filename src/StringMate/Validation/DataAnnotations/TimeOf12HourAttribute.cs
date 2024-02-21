using System.ComponentModel.DataAnnotations;
using System.Globalization;
using StringMate.Validation.ValidationRules;

namespace StringMate.Validation.DataAnnotations
{
    public class TimeOf12HourAttribute : ValidationAttribute
    {
        private readonly bool _includeSecond;

        public TimeOf12HourAttribute(bool includeSecond) =>
            _includeSecond = includeSecond;

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && TimeOf12HourValidation.Validate(str, _includeSecond);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid 12 hour based time.");
    }
}
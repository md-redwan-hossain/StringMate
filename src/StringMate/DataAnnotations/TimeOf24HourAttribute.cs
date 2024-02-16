using System.ComponentModel.DataAnnotations;
using System.Globalization;
using StringMate.ValidationRules;

namespace StringMate.DataAnnotations
{
    internal class TimeOf24HourAttribute : ValidationAttribute
    {
        private readonly bool _includeSecond;

        public TimeOf24HourAttribute(bool includeSecond) =>
            _includeSecond = includeSecond;

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && TimeOf24HourValidation.Validate(str, _includeSecond);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid 24 hour based time.");
    }
}
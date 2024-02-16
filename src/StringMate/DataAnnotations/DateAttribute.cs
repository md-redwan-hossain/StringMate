using System.ComponentModel.DataAnnotations;
using System.Globalization;
using StringMate.Helpers;
using StringMate.ValidationRules;

namespace StringMate.DataAnnotations
{
    public class DateAttribute : ValidationAttribute
    {
        public DateAttribute()
        {
            _dateFormat = new DateFormatBuilder()
                .AddDayWithLeadingZero()
                .AddMonthWithLeadingZero()
                .AddYearWithFourDigit()
                .AddHyphenDelimiter()
                .Build();
        }

        public DateAttribute(string dateFormat) => _dateFormat = dateFormat;

        private readonly string _dateFormat;

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && DateValidation.Validate(str, _dateFormat);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture,
                $"The field is not a valid date of the format {_dateFormat}.");
    }
}
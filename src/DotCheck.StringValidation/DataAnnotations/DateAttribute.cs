using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.Helpers;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations
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

        public override bool IsValid(object? value) =>
            DateValidation.Validate(Transformation.MakeValidString(value), _dateFormat);

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture,
                $"The field is not a valid date of the format {_dateFormat}.");
    }
}
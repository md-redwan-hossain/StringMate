using System;
using System.Globalization;

namespace StringMate.Validation.ValidationRules
{
    internal static class DateValidation
    {
        internal static bool Validate(string value, string dateFormat) =>
            DateTime.TryParseExact(value, dateFormat, null, DateTimeStyles.None, out _);
    }
}
using System.Text.RegularExpressions;

namespace StringMate.Validation.ValidationRules
{
    internal static class TimeOf12HourValidation
    {
        private static readonly Regex Hour12Regex =
            new("^(0?[1-9]|1[0-2]):([0-5][0-9]) (A|P)M$");

        private static readonly Regex Hour12WithSecondsRegex =
            new("^(0?[1-9]|1[0-2]):([0-5][0-9]):([0-5][0-9]) (A|P)M$");

        internal static bool Validate(string value, bool includeSecond)
        {
            return includeSecond
                ? Hour12WithSecondsRegex.IsMatch(value)
                : Hour12Regex.IsMatch(value);
        }
    }
}
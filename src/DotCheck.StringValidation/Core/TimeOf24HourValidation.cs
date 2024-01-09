using System.Text.RegularExpressions;

namespace DotCheck.StringValidation.Core;

public static class TimeOf24HourValidation
{
    private static readonly Regex Hour24Regex =
        new("^([01]?[0-9]|2[0-3]):([0-5][0-9])$");

    private static readonly Regex Hour24WithSecondsRegex =
        new("^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

    public static bool IsTimeOf24Hour(this IDotCheckStringValidation _, string value, bool includeSecond)
    {
        return includeSecond
            ? Hour24WithSecondsRegex.IsMatch(value)
            : Hour24Regex.IsMatch(value);
    }
}
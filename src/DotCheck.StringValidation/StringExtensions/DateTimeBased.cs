using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class DateTimeBased
{
    public static bool IsTime(this string text) =>
        new TimeValidation().Validate(text);

    public static bool IsTime(this string text, bool use24HourClock, bool useSecond) =>
        new TimeValidation().Validate(text, use24HourClock, useSecond);

}
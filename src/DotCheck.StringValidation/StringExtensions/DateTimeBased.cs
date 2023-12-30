using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class DateTimeBased
{
    public static bool Is12HourTime(this string text, bool includeSecond) =>
        new TimeOf12HourValidation().Validate(text, includeSecond);

    public static bool Is24HourTime(this string text, bool includeSecond) =>
        new TimeOf24HourValidation().Validate(text, includeSecond);
}
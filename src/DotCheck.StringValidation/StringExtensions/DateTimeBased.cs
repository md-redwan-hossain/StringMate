using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class DateTimeBased
{
    public static bool Is12HourTime(this IDotCheckStringValidation instance, bool includeSecond) =>
        new TimeOf12HourValidation().Validate(instance.TextDataForValidation, includeSecond);

    public static bool Is24HourTime(this IDotCheckStringValidation instance, bool includeSecond) =>
        new TimeOf24HourValidation().Validate(instance.TextDataForValidation, includeSecond);
}
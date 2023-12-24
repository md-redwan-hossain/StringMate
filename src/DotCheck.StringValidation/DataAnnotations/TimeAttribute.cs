using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class TimeAttribute : ValidationAttribute
{
    public TimeAttribute()
    {
        UseSecond = false;
        Use24HourClock = false;
    }

    public TimeAttribute(bool use24HourClock, bool useSecond)
    {
        UseSecond = useSecond;
        Use24HourClock = use24HourClock;
    }

    private bool Use24HourClock { get; init; }
    private bool UseSecond { get; init; }

    public override bool IsValid(object? value) =>
        new TimeValidation().Validate(value, Use24HourClock, UseSecond);

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid time.");
}
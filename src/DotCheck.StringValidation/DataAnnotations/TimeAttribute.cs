using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class TimeAttribute : ValidationAttribute
{
    public TimeAttribute(bool use24HourClock, bool useSecond)
    {
        UseSecond = useSecond;
        Use24HourClock = use24HourClock;
    }

    private bool Use24HourClock { get; init; }
    private bool UseSecond { get; init; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return new TimeValidation().Validate(value, Use24HourClock, UseSecond)
            ? ValidationResult.Success
            : new ValidationResult($"The {validationContext.DisplayName} field is not a valid time.");
    }
}
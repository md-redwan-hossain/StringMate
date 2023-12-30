using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class TimeOf24HourAttribute : ValidationAttribute
{
    private readonly bool _includeSecond;

    public TimeOf24HourAttribute(bool includeSecond) =>
        _includeSecond = includeSecond;

    public override bool IsValid(object? value) =>
        new TimeOf24HourValidation().Validate(value, _includeSecond);

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid 24 hour based time.");
}
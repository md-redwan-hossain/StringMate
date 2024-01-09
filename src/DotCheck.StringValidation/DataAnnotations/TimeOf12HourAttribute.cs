using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.Core;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations;

public class TimeOf12HourAttribute : ValidationAttribute
{
    private readonly bool _includeSecond;

    public TimeOf12HourAttribute(bool includeSecond) =>
        _includeSecond = includeSecond;

    public override bool IsValid(object? value) =>
        new DotCheckStringValidation().IsTimeOf12Hour(Transformation.MakeValidString(value), _includeSecond);

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid 12 hour based time.");
}
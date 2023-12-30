using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class TimeOf24HourValidation : IParameterizedValidation<bool>
{
    private static readonly Regex Hour24Regex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9])$");

    private static readonly Regex Hour24WithSecondsRegex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

    public bool Validate(object? value, bool includeSecond)
    {
        var validString = Transformation.MakeValidString(value);

        return includeSecond
            ? Hour24WithSecondsRegex.IsMatch(validString)
            : Hour24Regex.IsMatch(validString);
    }
}
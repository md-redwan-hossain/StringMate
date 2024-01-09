using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;

namespace DotCheck.StringValidation.CoreValidators;

public class TimeOf24HourValidation : IParameterizedValidation<bool>
{
    private static readonly Regex Hour24Regex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9])$");

    private static readonly Regex Hour24WithSecondsRegex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

    public bool Validate(string value, bool includeSecond)
    {
        return includeSecond
            ? Hour24WithSecondsRegex.IsMatch(value)
            : Hour24Regex.IsMatch(value);
    }
}
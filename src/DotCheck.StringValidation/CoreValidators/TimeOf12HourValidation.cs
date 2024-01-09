using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;

namespace DotCheck.StringValidation.CoreValidators;

public class TimeOf12HourValidation : IParameterizedValidation<bool>
{
    private static readonly Regex Hour12Regex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]) (A|P)M$");

    private static readonly Regex Hour12WithSecondsRegex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]):([0-5][0-9]) (A|P)M$");

    public bool Validate(string value, bool includeSecond)
    {
        return includeSecond
            ? Hour12WithSecondsRegex.IsMatch(value)
            : Hour12Regex.IsMatch(value);
    }
}
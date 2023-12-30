using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class TimeOf12HourValidation : IParameterizedValidation<bool>
{
    private static readonly Regex Hour12Regex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]) (A|P)M$");

    private static readonly Regex Hour12WithSecondsRegex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]):([0-5][0-9]) (A|P)M$");

    public bool Validate(object? value, bool includeSecond)
    {
        var validString = Transformation.MakeValidString(value);

        return includeSecond
            ? Hour12WithSecondsRegex.IsMatch(validString)
            : Hour12Regex.IsMatch(validString);
    }
}
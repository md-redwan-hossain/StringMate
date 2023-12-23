using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class TimeValidation : IValidation
{
    private static readonly Regex Hour24Regex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9])$");

    private static readonly Regex Hour24WithSecondsRegex =
        new(@"^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

    private static readonly Regex Hour12Regex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]) (A|P)M$");

    private static readonly Regex Hour12WithSecondsRegex =
        new(@"^(0?[1-9]|1[0-2]):([0-5][0-9]):([0-5][0-9]) (A|P)M$");

    public bool Validate(object? value) =>
        Hour12Regex.IsMatch(Transformation.MakeValidString(value));

    public bool Validate(object? value, bool useHour24, bool useSecond)
    {
        var validString = Transformation.MakeValidString(value);

        if (useHour24 && useSecond)
            return Hour24WithSecondsRegex.IsMatch(validString);

        if (useHour24 && !useSecond)
            return Hour24Regex.IsMatch(validString);

        if (!useHour24 && useSecond)
            return Hour12WithSecondsRegex.IsMatch(validString);

        return Hour12Regex.IsMatch(validString);
    }
}
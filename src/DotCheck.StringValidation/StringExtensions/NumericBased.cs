using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class NumericBased
{
    public static bool IsHexadecimal(this string text) =>
        new HexadecimalValidation().Validate(text);
}
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class NumericBased
{
    public static bool IsHexadecimal(this IDotCheckStringValidation instance) =>
        new HexadecimalValidation().Validate(instance.TextDataForValidation);
}
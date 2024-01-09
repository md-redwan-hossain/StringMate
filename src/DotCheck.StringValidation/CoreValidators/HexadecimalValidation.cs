using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class HexadecimalValidation : IValidation
{
    private static readonly Regex HexadecimalRegex =
        new(@"^(0x|0h)?[0-9A-F]+$", RegexOptions.IgnoreCase);

    public bool Validate(string value) =>
        HexadecimalRegex.IsMatch(Transformation.MakeValidString(value));
}
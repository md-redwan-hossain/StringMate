using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.Core;

public static class HexadecimalValidation 
{
    private static readonly Regex HexadecimalRegex =
        new("^(0x|0h)?[0-9A-F]+$", RegexOptions.IgnoreCase);

    public static bool IsHexadecimal(this IDotCheckStringValidation _,string value) =>
        HexadecimalRegex.IsMatch(Transformation.MakeValidString(value));
}
using System.Text.RegularExpressions;

namespace StringMate.ValidationRules
{
    internal static class HexadecimalValidation
    {
        private static readonly Regex HexadecimalRegex =
            new("^(0x|0h)?[0-9A-F]+$", RegexOptions.IgnoreCase);

        internal static bool Validate(string value) =>
            HexadecimalRegex.IsMatch(value);
    }
}
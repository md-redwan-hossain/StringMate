using System.Text.RegularExpressions;

namespace StringMate.Validation.ValidationRules
{
    internal static class Base64Validation
    {
        private static readonly Regex NotBase64Regex =
            new("[^A-Z0-9+\\/=]", RegexOptions.IgnoreCase);

        private static readonly Regex UrlSafeBase64Regex =
            new("^[A-Z0-9_\\-]*$", RegexOptions.IgnoreCase);


        internal static bool Validate(string value, bool checkUrlSafety)
        {
            if (checkUrlSafety) return UrlSafeBase64Regex.IsMatch(value);

            var length = value.Length;
            if (length % 4 != 0 || NotBase64Regex.IsMatch(value)) return false;

            var firstPaddingChar = value.IndexOf('=');

            return firstPaddingChar == -1 || firstPaddingChar == length - 1 ||
                   (firstPaddingChar == length - 2 && value[length - 1] == '=');
        }
    }
}
using System.Text.RegularExpressions;

namespace DotCheck.StringValidation.CoreValidators
{
    internal static class SlugValidation
    {
        private static readonly Regex CharsetRegex =
            new(@"^[^\s-_](?!.*?[-_]{2,})[a-z0-9-\\][^\s]*[^-_\s]$");

        internal static bool Validate(string value) =>
            CharsetRegex.IsMatch(value);
    }
}
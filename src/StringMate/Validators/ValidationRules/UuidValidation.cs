using System.Text.RegularExpressions;
using StringMate.Enums;

namespace StringMate.Validators.ValidationRules
{
    internal static class UuidValidation
    {
        private static readonly Regex UuidV1Regex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-1[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

        private static readonly Regex UuidV2Regex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-2[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

        private static readonly Regex UuidV3Regex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-3[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

        private static readonly Regex UuidV4Regex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-4[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

        private static readonly Regex UuidV5Regex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-5[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

        private static readonly Regex UuidAllRegex =
            new Regex("^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);


        internal static bool Validate(string value, UuidVersion version)
        {
            return version switch
            {
                UuidVersion.V1 => UuidV1Regex.IsMatch(value),
                UuidVersion.V2 => UuidV2Regex.IsMatch(value),
                UuidVersion.V3 => UuidV3Regex.IsMatch(value),
                UuidVersion.V4 => UuidV4Regex.IsMatch(value),
                UuidVersion.V5 => UuidV5Regex.IsMatch(value),
                _ => UuidAllRegex.IsMatch(value)
            };
        }
    }
}
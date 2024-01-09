using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.CoreValidators.Interfaces;

namespace DotCheck.StringValidation.CoreValidators;

public class UuidValidation : IParameterizedValidation<UuidVersion>
{
    private static readonly Regex UuidV1Regex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-1[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

    private static readonly Regex UuidV2Regex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-2[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

    private static readonly Regex UuidV3Regex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-3[0-9A-F]{3}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

    private static readonly Regex UuidV4Regex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-4[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

    private static readonly Regex UuidV5Regex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-5[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);

    private static readonly Regex UuidAllRegex =
        new(@"^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$", RegexOptions.IgnoreCase);


    public bool Validate(string value, UuidVersion version)
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
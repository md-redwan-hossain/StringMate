using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class UuidValidation : IValidation
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


    public bool Validate(object? value) =>
        UuidAllRegex.IsMatch(Transformation.MakeValidString(value));


    public bool Validate(object? value, UuidVersion version)
    {
        var validString = Transformation.MakeValidString(value);

        return version switch
        {
            UuidVersion.V1 => UuidV1Regex.IsMatch(validString),
            UuidVersion.V2 => UuidV2Regex.IsMatch(validString),
            UuidVersion.V3 => UuidV3Regex.IsMatch(validString),
            UuidVersion.V4 => UuidV4Regex.IsMatch(validString),
            UuidVersion.V5 => UuidV5Regex.IsMatch(validString),
            _ => UuidAllRegex.IsMatch(validString)
        };
    }
}
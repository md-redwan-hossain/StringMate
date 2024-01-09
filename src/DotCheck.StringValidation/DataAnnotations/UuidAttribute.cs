using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.Core;
using DotCheck.StringValidation.Core.Enums;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations;

public class UuidAttribute : ValidationAttribute
{
    public UuidAttribute() => _version = UuidVersion.All;
    public UuidAttribute(UuidVersion version) => _version = version;

    private readonly UuidVersion _version;

    public override bool IsValid(object? value) =>
        new DotCheckStringValidation().IsUuid(Transformation.MakeValidString(value), _version);

    public override string FormatErrorMessage(string name)
    {
        var errorMsg = (_version == UuidVersion.All)
            ? "The field is not a valid uuid."
            : $"The field is not a valid uuid of version {(byte)_version}.";

        return string.Format(CultureInfo.CurrentCulture, errorMsg);
    }
}
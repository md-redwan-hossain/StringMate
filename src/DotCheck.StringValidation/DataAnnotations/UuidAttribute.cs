using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.DataAnnotations;

public class UuidAttribute : ValidationAttribute
{
    public UuidAttribute() => Version = UuidVersion.All;
    public UuidAttribute(UuidVersion version) => Version = version;
    private UuidVersion Version { get; init; }

    public override bool IsValid(object? value) =>
        new UuidValidation().Validate(value, Version);

    public override string FormatErrorMessage(string name)
    {
        var errorMsg = (Version == UuidVersion.All)
            ? "The field is not a valid uuid."
            : $"The field is not a valid uuid of version {(byte)Version}.";

        return string.Format(CultureInfo.CurrentCulture, errorMsg);
    }
}
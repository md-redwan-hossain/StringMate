using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.DataAnnotations;

public class UuidAttribute : ValidationAttribute
{
    public UuidAttribute(UuidVersion version) => Version = version;
    private UuidVersion Version { get; init; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return new UuidValidation().Validate(value, Version)
            ? ValidationResult.Success
            : new ValidationResult(GetErrorMessage(Version));

        string GetErrorMessage(UuidVersion version) =>
            version == UuidVersion.All
                ? $"The {validationContext.DisplayName} field is not a valid uuid."
                : $"The {validationContext.DisplayName} field is not a valid uuid of version {(byte)version}.";
    }
}
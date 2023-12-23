using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.DataAnnotations;

public class UuidAttribute : ValidationAttribute
{
    public UuidAttribute(UuidVersion version) =>
        Version = version;

    public UuidVersion Version { get; private set; }

    public override bool IsValid(object? value) =>
        new UuidValidation().Validate(value, Version = UuidVersion.All);
}
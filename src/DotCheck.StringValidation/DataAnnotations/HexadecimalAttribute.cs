using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class HexadecimalAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return new HexadecimalValidation().Validate(value)
            ? ValidationResult.Success
            : new ValidationResult($"The {validationContext.DisplayName} field is not a valid hex.");
    }
}
using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class JsonWebTokenAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return new JsonWebTokenValidation().Validate(value)
            ? ValidationResult.Success
            : new ValidationResult($"The {validationContext.DisplayName} field is not a valid json web token.");
    }
}
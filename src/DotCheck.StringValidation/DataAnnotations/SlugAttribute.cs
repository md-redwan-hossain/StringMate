using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class SlugAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return new SlugValidation().Validate(value)
            ? ValidationResult.Success
            : new ValidationResult($"The {validationContext.DisplayName} field is not a valid slug.");
    }
}
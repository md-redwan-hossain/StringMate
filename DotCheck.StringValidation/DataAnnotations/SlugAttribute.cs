using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class SlugAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new SlugValidation().Validate(value);
}
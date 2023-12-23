using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class JsonWebTokenAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new JsonWebTokenValidation().Validate(value);
}